﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ZtherApiIntegration.API.Models
{
    public partial class ProductReviewUpdate
    {
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private bool? _isApproved;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsApproved
        {
            get { return this._isApproved; }
            set { this._isApproved = value; }
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
        
        /// <summary>
        /// Initializes a new instance of the ProductReviewUpdate class.
        /// </summary>
        public ProductReviewUpdate()
        {
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type ProductReviewUpdate
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.ID != null)
            {
                outputObject["id"] = this.ID.Value;
            }
            if (this.IsApproved != null)
            {
                outputObject["isApproved"] = this.IsApproved.Value;
            }
            if (this.ProductCode != null)
            {
                outputObject["productCode"] = this.ProductCode;
            }
            return outputObject;
        }
    }
}
