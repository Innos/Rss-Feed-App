namespace RssFeed.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using RssFeed.Web.Models;

    using RSSFeed.Data;
    using RSSFeed.Data.Models;

    public class PersonalFeedsController : Controller
    {
        private RssFeedDbContext db = new RssFeedDbContext();

        // GET: PersonalFeeds
        public ActionResult Index()
        {
            var personalFeeds = this.db.PersonalFeeds.Include(p => p.Category).Include(p => p.Feed);
            return this.View(personalFeeds.ToList());
        }

        // GET: PersonalFeeds/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalFeed personalFeed = this.db.PersonalFeeds.Find(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }
            return this.View(personalFeed);
        }

        // GET: PersonalFeeds/Create
        public ActionResult Create()
        {
            this.ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name");
            this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url");
            return this.View();
        }

        // POST: PersonalFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalFeedViewModel personalFeedViewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.db.PersonalFeeds.Add(personalFeedViewModel);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", personalFeedViewModel.CategoryId);
            //this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url", personalFeedViewModel.FeedId);
            return this.View(personalFeedViewModel);
        }

        // GET: PersonalFeeds/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalFeed personalFeed = this.db.PersonalFeeds.Find(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }
            this.ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", personalFeed.CategoryId);
            this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url", personalFeed.FeedId);
            return this.View(personalFeed);
        }

        // POST: PersonalFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,FeedId,LastKnownArticleId,IsDeleted,DeletedOn")] PersonalFeed personalFeed)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(personalFeed).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.CategoryId = new SelectList(this.db.Categories, "Id", "Name", personalFeed.CategoryId);
            this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url", personalFeed.FeedId);
            return this.View(personalFeed);
        }

        // GET: PersonalFeeds/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalFeed personalFeed = this.db.PersonalFeeds.Find(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }
            return this.View(personalFeed);
        }

        // POST: PersonalFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PersonalFeed personalFeed = this.db.PersonalFeeds.Find(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }

            this.db.PersonalFeeds.Remove(personalFeed);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
