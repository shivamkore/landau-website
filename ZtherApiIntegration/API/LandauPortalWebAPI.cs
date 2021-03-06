﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Rest;
using ZtherApiIntegration.API;

namespace ZtherApiIntegration.API
{
    public partial class LandauPortalWebAPI : ServiceClient<LandauPortalWebAPI>, ILandauPortalWebAPI
    {
        private readonly string API_ENDPOINT = System.Configuration.ConfigurationManager.AppSettings["API-Endpoint"];

        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IBanners _banners;
        
        public virtual IBanners Banners
        {
            get { return this._banners; }
        }
        
        private IBrands _brands;
        
        public virtual IBrands Brands
        {
            get { return this._brands; }
        }
        
        private ICache _cache;
        
        public virtual ICache Cache
        {
            get { return this._cache; }
        }
        
        private ICatalogs _catalogs;
        
        public virtual ICatalogs Catalogs
        {
            get { return this._catalogs; }
        }
        
        private IColors _colors;
        
        public virtual IColors Colors
        {
            get { return this._colors; }
        }
        
        private IContactUsOperations _contactUs;
        
        public virtual IContactUsOperations ContactUs
        {
            get { return this._contactUs; }
        }
        
        private ICountries _countries;
        
        public virtual ICountries Countries
        {
            get { return this._countries; }
        }
        
        private IEmailFavorites _emailFavorites;
        
        public virtual IEmailFavorites EmailFavorites
        {
            get { return this._emailFavorites; }
        }
        
        private IGroupOrders _groupOrders;
        
        public virtual IGroupOrders GroupOrders
        {
            get { return this._groupOrders; }
        }
        
        private IImages _images;
        
        public virtual IImages Images
        {
            get { return this._images; }
        }
        
        private IProductImages _productImages;
        
        public virtual IProductImages ProductImages
        {
            get { return this._productImages; }
        }
        
        private IProductReviews _productReviews;
        
        public virtual IProductReviews ProductReviews
        {
            get { return this._productReviews; }
        }
        
        private IProducts _products;
        
        public virtual IProducts Products
        {
            get { return this._products; }
        }
        
        private IQuestions _questions;
        
        public virtual IQuestions Questions
        {
            get { return this._questions; }
        }
        
        private IRetailers _retailers;
        
        public virtual IRetailers Retailers
        {
            get { return this._retailers; }
        }
        
        private ISeoOperations _seo;
        
        public virtual ISeoOperations Seo
        {
            get { return this._seo; }
        }
        
        private ISignUps _signUps;
        
        public virtual ISignUps SignUps
        {
            get { return this._signUps; }
        }
        
        private IStates _states;
        
        public virtual IStates States
        {
            get { return this._states; }
        }
        
        private ISwatches _swatches;
        
        public virtual ISwatches Swatches
        {
            get { return this._swatches; }
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        public LandauPortalWebAPI()
            : base()
        {
            this._banners = new Banners(this);
            this._brands = new Brands(this);
            this._cache = new Cache(this);
            this._catalogs = new Catalogs(this);
            this._colors = new Colors(this);
            this._contactUs = new ContactUsOperations(this);
            this._countries = new Countries(this);
            this._emailFavorites = new EmailFavorites(this);
            this._groupOrders = new GroupOrders(this);
            this._images = new Images(this);
            this._productImages = new ProductImages(this);
            this._productReviews = new ProductReviews(this);
            this._products = new Products(this);
            this._questions = new Questions(this);
            this._retailers = new Retailers(this);
            this._seo = new SeoOperations(this);
            this._signUps = new SignUps(this);
            this._states = new States(this);
            this._swatches = new Swatches(this);
            this._baseUri = new Uri(API_ENDPOINT);
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public LandauPortalWebAPI(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._banners = new Banners(this);
            this._brands = new Brands(this);
            this._cache = new Cache(this);
            this._catalogs = new Catalogs(this);
            this._colors = new Colors(this);
            this._contactUs = new ContactUsOperations(this);
            this._countries = new Countries(this);
            this._emailFavorites = new EmailFavorites(this);
            this._groupOrders = new GroupOrders(this);
            this._images = new Images(this);
            this._productImages = new ProductImages(this);
            this._productReviews = new ProductReviews(this);
            this._products = new Products(this);
            this._questions = new Questions(this);
            this._retailers = new Retailers(this);
            this._seo = new SeoOperations(this);
            this._signUps = new SignUps(this);
            this._states = new States(this);
            this._swatches = new Swatches(this);
            this._baseUri = new Uri(API_ENDPOINT);
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public LandauPortalWebAPI(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._banners = new Banners(this);
            this._brands = new Brands(this);
            this._cache = new Cache(this);
            this._catalogs = new Catalogs(this);
            this._colors = new Colors(this);
            this._contactUs = new ContactUsOperations(this);
            this._countries = new Countries(this);
            this._emailFavorites = new EmailFavorites(this);
            this._groupOrders = new GroupOrders(this);
            this._images = new Images(this);
            this._productImages = new ProductImages(this);
            this._productReviews = new ProductReviews(this);
            this._products = new Products(this);
            this._questions = new Questions(this);
            this._retailers = new Retailers(this);
            this._seo = new SeoOperations(this);
            this._signUps = new SignUps(this);
            this._states = new States(this);
            this._swatches = new Swatches(this);
            this._baseUri = new Uri(API_ENDPOINT);
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public LandauPortalWebAPI(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public LandauPortalWebAPI(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the LandauPortalWebAPI class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public LandauPortalWebAPI(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
    }
}
