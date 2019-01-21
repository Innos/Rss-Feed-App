namespace RssFeed.Web.Controllers
{
    using System.Linq;
    using System.Transactions;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using RssFeed.Services.Feeds;
    using RssFeed.Services.PersonalCategories;
    using RssFeed.Services.UsersService;
    using RssFeed.Web.Models;

    using RssFeed.Data.Models;
    using RssFeed.Data.Repositories.Contracts;

    public class PersonalFeedsController : BaseAuthorizedController
    {
        private readonly IDeletableEntityRepository<Feed> feedsRepository;
        private readonly IDeletableEntityRepository<PersonalFeed> personalFeedsRepository;
        private readonly IFeedsService feedsService;
        private readonly IPersonalCategoriesService personalCategoriesService;

        public PersonalFeedsController(
            IUsersService<User> usersService,
            IDeletableEntityRepository<Feed> feedsRepository,
            IDeletableEntityRepository<PersonalFeed> personalFeedsRepository,
            IFeedsService feedsService,
            IPersonalCategoriesService personalCategoriesService) 
            : base(usersService)
        {
            this.feedsRepository = feedsRepository;
            this.personalFeedsRepository = personalFeedsRepository;
            this.feedsService = feedsService;
            this.personalCategoriesService = personalCategoriesService;
        }

        // GET: PersonalFeeds
        public ActionResult Index()
        {
            var personalFeedViewModels = 
                this.personalFeedsRepository
                .All()
                .ProjectTo<PersonalFeedViewModel>()
                .ToList();

            return this.View(personalFeedViewModels);
        }

        // GET: PersonalFeeds/Details/5
        public ActionResult Details(long? id)
        {
            PersonalFeed personalFeed = this.personalFeedsRepository.GetById(id);

            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }

            var personalFeedViewModel = Mapper.Map<PersonalFeedViewModel>(personalFeed);

            return this.View(personalFeedViewModel);
        }

        // GET: PersonalFeeds/Create
        public ActionResult Create()
        {
            var categories = this.personalCategoriesService.GetByUser(this.UserProfile.Id);
            this.ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            //this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url");
            return this.View();
        }

        // POST: PersonalFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalFeedInputModel personalFeedInputModel)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.feedsService.ExistsByUrl(personalFeedInputModel.Url))
                {
                    this.feedsRepository.Add(new Feed() {Url = personalFeedInputModel.Url});    
                }

                var feed = this.feedsService.GetByUrl(personalFeedInputModel.Url);

                var personalFeed = Mapper.Map<PersonalFeed>(personalFeedInputModel);
                personalFeed.FeedId = feed.Id;

                this.personalFeedsRepository.Add(personalFeed);
                this.feedsRepository.SaveChanges();

                //this.db.PersonalFeeds.Add(personalFeed);
                //this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            var categories = this.personalCategoriesService.GetByUser(this.UserProfile.Id);
            this.ViewBag.CategoryId = new SelectList(categories, "Id", "Name", personalFeedInputModel.CategoryId);
            //this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url", personalFeedViewModel.FeedId);
            return this.View(personalFeedInputModel);
        }

        // GET: PersonalFeeds/Edit/5
        public ActionResult Edit(long? id)
        {
            var personalFeed = this.personalFeedsRepository.GetById(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }

            var categories = this.personalCategoriesService.GetByUser(this.UserProfile.Id);
            this.ViewBag.CategoryId = new SelectList(categories, "Id", "Name", personalFeed.CategoryId);
            //this.ViewBag.FeedId = new SelectList(this.db.Feeds, "Id", "Url", personalFeed.FeedId);

            var personalFeedInputModel = Mapper.Map<PersonalFeedInputModel>(personalFeed);

            return this.View(personalFeedInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalFeedInputModel personalFeedInputModel)
        {
            if (this.ModelState.IsValid)
            {
                using (var transaction = new TransactionScope())
                {
                    if (!this.feedsService.ExistsByUrl(personalFeedInputModel.Url))
                    {
                        this.feedsRepository.Add(new Feed() { Url = personalFeedInputModel.Url });
                    }
                }

                var feed = this.feedsService.GetByUrl(personalFeedInputModel.Url);

                var personalFeed = Mapper.Map<PersonalFeed>(personalFeedInputModel);
                personalFeed.FeedId = feed.Id;

                this.personalFeedsRepository.Update(personalFeed);
                this.feedsRepository.SaveChanges();

                return this.RedirectToAction("Index");
            }

            var categories = this.personalCategoriesService.GetByUser(this.UserProfile.Id);
            this.ViewBag.CategoryId = new SelectList(categories, "Id", "Name", personalFeedInputModel.CategoryId);
            
            return this.View(personalFeedInputModel);
        }

        // GET: PersonalFeeds/Delete/5
        public ActionResult Delete(long? id)
        {
            var personalFeed = this.personalFeedsRepository.GetById(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }

            var personalFeedViewModel = Mapper.Map<PersonalFeedViewModel>(personalFeed);
            return this.View(personalFeedViewModel);
        }

        // POST: PersonalFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var personalFeed = this.personalFeedsRepository.GetById(id);
            if (personalFeed == null)
            {
                return this.HttpNotFound();
            }

            this.personalFeedsRepository.Delete(id);
            this.personalFeedsRepository.SaveChanges();

            //this.db.PersonalFeeds.Remove(personalFeed);
            //this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
