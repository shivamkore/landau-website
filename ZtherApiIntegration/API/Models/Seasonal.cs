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
    public partial class Seasonal
    {
        private string _brand;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Brand
        {
            get { return this._brand; }
            set { this._brand = value; }
        }
        
        private string _collection;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Collection
        {
            get { return this._collection; }
            set { this._collection = value; }
        }
        
        private DateTimeOffset? _dateAdded;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? DateAdded
        {
            get { return this._dateAdded; }
            set { this._dateAdded = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private bool? _enabled;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }
        
        private string _gender;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Gender
        {
            get { return this._gender; }
            set { this._gender = value; }
        }
        
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _imageUri;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ImageUri
        {
            get { return this._imageUri; }
            set { this._imageUri = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private IList<SeasonalItem> _products;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<SeasonalItem> Products
        {
            get { return this._products; }
            set { this._products = value; }
        }
        
        private int? _sortOrder;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? SortOrder
        {
            get { return this._sortOrder; }
            set { this._sortOrder = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Seasonal class.
        /// </summary>
        public Seasonal()
        {
            this.Products = new LazyList<SeasonalItem>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken brandValue = inputObject["brand"];
                if (brandValue != null && brandValue.Type != JTokenType.Null)
                {
                    this.Brand = ((string)brandValue);
                }
                JToken collectionValue = inputObject["collection"];
                if (collectionValue != null && collectionValue.Type != JTokenType.Null)
                {
                    this.Collection = ((string)collectionValue);
                }
                JToken dateAddedValue = inputObject["dateAdded"];
                if (dateAddedValue != null && dateAddedValue.Type != JTokenType.Null)
                {
                    this.DateAdded = ((DateTimeOffset)dateAddedValue);
                }
                JToken descriptionValue = inputObject["description"];
                if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                {
                    this.Description = ((string)descriptionValue);
                }
                JToken enabledValue = inputObject["enabled"];
                if (enabledValue != null && enabledValue.Type != JTokenType.Null)
                {
                    this.Enabled = ((bool)enabledValue);
                }
                JToken genderValue = inputObject["gender"];
                if (genderValue != null && genderValue.Type != JTokenType.Null)
                {
                    this.Gender = ((string)genderValue);
                }
                JToken idValue = inputObject["id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.ID = ((int)idValue);
                }
                JToken imageUriValue = inputObject["imageUri"];
                if (imageUriValue != null && imageUriValue.Type != JTokenType.Null)
                {
                    this.ImageUri = ((string)imageUriValue);
                }
                JToken nameValue = inputObject["name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken productsSequence = ((JToken)inputObject["products"]);
                if (productsSequence != null && productsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken productsValue in ((JArray)productsSequence))
                    {
                        SeasonalItem seasonalItem = new SeasonalItem();
                        seasonalItem.DeserializeJson(productsValue);
                        this.Products.Add(seasonalItem);
                    }
                }
                JToken sortOrderValue = inputObject["sortOrder"];
                if (sortOrderValue != null && sortOrderValue.Type != JTokenType.Null)
                {
                    this.SortOrder = ((int)sortOrderValue);
                }
            }
        }
    }
}
