using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace TransportMVC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public NotificationController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Notification
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            // Fetch notifications based on user role and clearance status
            var notifications = User.IsInRole("Admin")
                ? await _context.Notifications.Include(n => n.LastModifiedBy).OrderByDescending(n => n.LastModifiedAt).ToListAsync()
                : await _context.Notifications.Include(n => n.LastModifiedBy)
                    .Where(n => n.ReceiverId == currentUser.Id && !n.IsCleared)
                    .OrderByDescending(n => n.LastModifiedAt)
                    .ToListAsync();

            // Mark all unread notifications for the current user as read
            foreach (var notification in notifications.Where(n => n.ReceiverId == currentUser.Id && !n.IsRead))
            {
                notification.IsRead = true;
                notification.Receiver.NbUnreadNotifications--;
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return View(notifications);
        }


        // GET: Notification/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(d => d.CreatedBy)
                .Include(d => d.Receiver)  
                .Include(d => d.LastModifiedBy) 
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notification/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(string userId)
        {
            ViewBag.Users = _userManager.Users.ToList();

            var notification = new Notification();
            if (!string.IsNullOrEmpty(userId))
            {
                notification.ReceiverId = userId;
            }

            return View(notification);
        }


        // POST: Notification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Content,ReceiverId")] Notification notification)
        {

            // Fetch the list of users from the database
            var users = await _context.Users.ToListAsync();
            
            ViewBag.Users = users;

            Console.WriteLine(notification.Content);
            Console.WriteLine(notification.ReceiverId);
            if (!ModelState.IsValid)
            {
                // Print validation errors to the console
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        Console.WriteLine(errorMessage);
                    }
                }
                
                return View(notification);
            }
            
            if (ModelState.IsValid)
            {
                // Set the CreatedBy and LastModifiedBy properties to the currently logged-in user
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                // Ensure that the current user is not null
                if (currentUser == null)
                {
                    // Handle the case where the current user is not found
                    return RedirectToAction(nameof(Index));
                }

                // Set the SentDate and LastModifiedAt properties
                notification.SentDate = DateTime.UtcNow;
                notification.LastModifiedAt = DateTime.UtcNow;

                // Set the CreatedBy and LastModifiedBy properties
                notification.CreatedBy = currentUser;
                notification.LastModifiedBy = currentUser;

                // Retrieve the receiver from the database using ReceiverId
                var receiver = await _userManager.FindByIdAsync(notification.ReceiverId);
                if (receiver == null)
                {
                    // Handle the case where the receiver is not found
                    ModelState.AddModelError("ReceiverId", "Invalid receiver selected.");
                    return View(notification);
                }

                // Set the Receiver property
                notification.Receiver = receiver;

                notification.Receiver.NbUnreadNotifications++;
                

                // Add the notification to the context and save changes
                _context.Add(notification);
                await _context.SaveChangesAsync();
                
                // Redirect to the Index action
                return RedirectToAction(nameof(Index));
            }
            // If the model state is not valid, return the view with the notification object
            return View(notification);
        }


        // GET: Notification/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = await _context.Users.ToListAsync();
            
            ViewBag.Users = users;

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Content,ReceiverId")] Notification notification)
        {
            if (id != notification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalNotification = await _context.Notifications.Include(c => c.Receiver).FirstOrDefaultAsync(c => c.Id == id);
                    if (originalNotification == null)
                    {
                        return NotFound();
                    }

                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    if (currentUser == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    // Preserve the original CreatedAt value
                    notification.SentDate = originalNotification.SentDate;

                    // Update the LastModifiedBy and LastModifiedAt properties
                    originalNotification.LastModifiedBy = currentUser;
                    originalNotification.LastModifiedAt = DateTime.UtcNow;

                    // Update the properties of the originalNotification with values from the notification object
                    originalNotification.Content = notification.Content;

                    // Retrieve the receiver from the database using ReceiverId
                    var receiver = await _userManager.FindByIdAsync(notification.ReceiverId);
                    if (receiver == null)
                    {
                        // Handle the case where the receiver is not found
                        ModelState.AddModelError("ReceiverId", "Invalid receiver selected.");
                        return View(notification);
                    }

                    // Set the Receiver property
                    originalNotification.Receiver = receiver;

                    if(originalNotification.IsRead)
                    {
                        originalNotification.Receiver.NbUnreadNotifications++;
                    }

                    originalNotification.IsRead = false;

                    

                    _context.Update(originalNotification);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index)); // Redirect to notification index or other relevant page
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError(string.Empty, "Concurrency conflict occurred. Please try again.");
                    // Log the exception for further investigation
                    return View(notification); // Return the view with error message
                }
            }
            return View(notification); // Return the view with validation errors
        }


        // GET: Notification/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var notification = await _context.Notifications.Include(n => n.Receiver).FirstOrDefaultAsync(n => n.Id == id);
            if (notification != null)
            {
                if (!notification.IsRead && notification.Receiver != null)
                {
                    notification.Receiver.NbUnreadNotifications--;
                }
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool NotificationExists(Guid id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }

        // POST: Notification/Clear/5
        [HttpPost, ActionName("Clear")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Clear(Guid id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                notification.IsCleared = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
