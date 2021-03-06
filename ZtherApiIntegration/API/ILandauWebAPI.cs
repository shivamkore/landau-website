﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Microsoft.Rest;
using ZtherApiIntegration.API;

namespace ZtherApiIntegration.API
{
    public partial interface ILandauWebAPI : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri
        {
            get; set; 
        }
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        ServiceClientCredentials Credentials
        {
            get; set; 
        }
        
        IBanners Banners
        {
            get; 
        }
        
        IBrands Brands
        {
            get; 
        }
        
        ICatalogs Catalogs
        {
            get; 
        }
        
        IColors Colors
        {
            get; 
        }
        
        IContactUsOperations ContactUs
        {
            get; 
        }
        
        ICountries Countries
        {
            get; 
        }
        
        IGroupOrders GroupOrders
        {
            get; 
        }
        
        IImages Images
        {
            get; 
        }
        
        IProductImages ProductImages
        {
            get; 
        }
        
        IProductReviews ProductReviews
        {
            get; 
        }
        
        IProducts Products
        {
            get; 
        }
        
        IQuestions Questions
        {
            get; 
        }
        
        IRetailers Retailers
        {
            get; 
        }
        
        ISeoOperations Seo
        {
            get; 
        }
        
        ISignUps SignUps
        {
            get; 
        }
        
        IStates States
        {
            get; 
        }
        
        ISwatches Swatches
        {
            get; 
        }
    }
}
