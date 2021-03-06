﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ZtherApiIntegration.API.Models
{
    public partial class ProductCatalog
    {
        private string _average;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Average
        {
            get { return this._average; }
            set { this._average = value; }
        }
        
        private string _brand;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Brand
        {
            get { return this._brand; }
            set { this._brand = value; }
        }
        
        private bool? _hasNewColor;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? HasNewColor
        {
            get { return this._hasNewColor; }
            set { this._hasNewColor = value; }
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
        
        private bool? _isNew;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsNew
        {
            get { return this._isNew; }
            set { this._isNew = value; }
        }
        
        private bool? _isPopular;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsPopular
        {
            get { return this._isPopular; }
            set { this._isPopular = value; }
        }
        
        private string _productCode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ProductCode
        {
            get { return this._productCode; }
            set { this._productCode = value; }
        }
        
        private string _productName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ProductName
        {
            get { return this._productName; }
            set { this._productName = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ProductCatalog class.
        /// </summary>
        public ProductCatalog()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken averageValue = inputObject["average"];
                if (averageValue != null && averageValue.Type != JTokenType.Null)
                {
                    this.Average = ((string)averageValue);
                }
                JToken brandValue = inputObject["brand"];
                if (brandValue != null && brandValue.Type != JTokenType.Null)
                {
                    this.Brand = ((string)brandValue);
                }
                JToken hasNewColorValue = inputObject["hasNewColor"];
                if (hasNewColorValue != null && hasNewColorValue.Type != JTokenType.Null)
                {
                    this.HasNewColor = ((bool)hasNewColorValue);
                }
                JToken imageUriValue = inputObject["imageUri"];
                if (imageUriValue != null && imageUriValue.Type != JTokenType.Null)
                {
                    this.ImageUri = ((string)imageUriValue);
                }
                JToken isNewValue = inputObject["isNew"];
                if (isNewValue != null && isNewValue.Type != JTokenType.Null)
                {
                    this.IsNew = ((bool)isNewValue);
                }
                JToken isPopularValue = inputObject["isPopular"];
                if (isPopularValue != null && isPopularValue.Type != JTokenType.Null)
                {
                    this.IsPopular = ((bool)isPopularValue);
                }
                JToken productCodeValue = inputObject["productCode"];
                if (productCodeValue != null && productCodeValue.Type != JTokenType.Null)
                {
                    this.ProductCode = ((string)productCodeValue);
                }
                JToken productNameValue = inputObject["productName"];
                if (productNameValue != null && productNameValue.Type != JTokenType.Null)
                {
                    this.ProductName = ((string)productNameValue);
                }
            }
        }
    }
}
