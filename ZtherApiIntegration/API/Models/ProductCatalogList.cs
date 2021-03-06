﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using ZtherApiIntegration.API.Models;

namespace ZtherApiIntegration.API.Models
{
    public partial class ProductCatalogList
    {
        private string _catalogImageUri;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string CatalogImageUri
        {
            get { return this._catalogImageUri; }
            set { this._catalogImageUri = value; }
        }
        
        private int? _count;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Count
        {
            get { return this._count; }
            set { this._count = value; }
        }
        
        private IList<string> _filters;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Filters
        {
            get { return this._filters; }
            set { this._filters = value; }
        }
        
        private string _mobileCatalogImageUri;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string MobileCatalogImageUri
        {
            get { return this._mobileCatalogImageUri; }
            set { this._mobileCatalogImageUri = value; }
        }
        
        private Pagination _pagination;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Pagination Pagination
        {
            get { return this._pagination; }
            set { this._pagination = value; }
        }
        
        private IList<ProductCatalog> _results;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<ProductCatalog> Results
        {
            get { return this._results; }
            set { this._results = value; }
        }
        
        private Seo _seo;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Seo Seo
        {
            get { return this._seo; }
            set { this._seo = value; }
        }
        
        private TextSlider _textSlider;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public TextSlider TextSlider
        {
            get { return this._textSlider; }
            set { this._textSlider = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ProductCatalogList class.
        /// </summary>
        public ProductCatalogList()
        {
            this.Filters = new LazyList<string>();
            this.Results = new LazyList<ProductCatalog>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken catalogImageUriValue = inputObject["catalogImageUri"];
                if (catalogImageUriValue != null && catalogImageUriValue.Type != JTokenType.Null)
                {
                    this.CatalogImageUri = ((string)catalogImageUriValue);
                }
                JToken countValue = inputObject["count"];
                if (countValue != null && countValue.Type != JTokenType.Null)
                {
                    this.Count = ((int)countValue);
                }
                JToken filtersSequence = ((JToken)inputObject["filters"]);
                if (filtersSequence != null && filtersSequence.Type != JTokenType.Null)
                {
                    foreach (JToken filtersValue in ((JArray)filtersSequence))
                    {
                        this.Filters.Add(((string)filtersValue));
                    }
                }
                JToken mobileCatalogImageUriValue = inputObject["mobileCatalogImageUri"];
                if (mobileCatalogImageUriValue != null && mobileCatalogImageUriValue.Type != JTokenType.Null)
                {
                    this.MobileCatalogImageUri = ((string)mobileCatalogImageUriValue);
                }
                JToken paginationValue = inputObject["pagination"];
                if (paginationValue != null && paginationValue.Type != JTokenType.Null)
                {
                    Pagination pagination = new Pagination();
                    pagination.DeserializeJson(paginationValue);
                    this.Pagination = pagination;
                }
                JToken resultsSequence = ((JToken)inputObject["results"]);
                if (resultsSequence != null && resultsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken resultsValue in ((JArray)resultsSequence))
                    {
                        ProductCatalog productCatalog = new ProductCatalog();
                        productCatalog.DeserializeJson(resultsValue);
                        this.Results.Add(productCatalog);
                    }
                }
                JToken seoValue = inputObject["seo"];
                if (seoValue != null && seoValue.Type != JTokenType.Null)
                {
                    Seo seo = new Seo();
                    seo.DeserializeJson(seoValue);
                    this.Seo = seo;
                }
                JToken textSliderValue = inputObject["textSlider"];
                if (textSliderValue != null && textSliderValue.Type != JTokenType.Null)
                {
                    TextSlider textSlider = new TextSlider();
                    textSlider.DeserializeJson(textSliderValue);
                    this.TextSlider = textSlider;
                }
            }
        }
    }
}
