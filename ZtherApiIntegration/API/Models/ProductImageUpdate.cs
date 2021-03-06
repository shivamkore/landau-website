﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ZtherApiIntegration.API.Models
{
    public partial class ProductImageUpdate
    {
        private int _id;
        
        /// <summary>
        /// Required.
        /// </summary>
        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private bool? _is360Display;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? Is360Display
        {
            get { return this._is360Display; }
            set { this._is360Display = value; }
        }
        
        private bool? _isLineArt;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsLineArt
        {
            get { return this._isLineArt; }
            set { this._isLineArt = value; }
        }
        
        private bool? _resize;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? Resize
        {
            get { return this._resize; }
            set { this._resize = value; }
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
        /// Initializes a new instance of the ProductImageUpdate class.
        /// </summary>
        public ProductImageUpdate()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ProductImageUpdate class with
        /// required arguments.
        /// </summary>
        public ProductImageUpdate(int id)
            : this()
        {
            this.ID = id;
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type ProductImageUpdate
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            outputObject["id"] = this.ID;
            if (this.Is360Display != null)
            {
                outputObject["is360Display"] = this.Is360Display.Value;
            }
            if (this.IsLineArt != null)
            {
                outputObject["isLineArt"] = this.IsLineArt.Value;
            }
            if (this.Resize != null)
            {
                outputObject["resize"] = this.Resize.Value;
            }
            if (this.SortOrder != null)
            {
                outputObject["sortOrder"] = this.SortOrder.Value;
            }
            return outputObject;
        }
    }
}
