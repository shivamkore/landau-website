﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ZtherApiIntegration.API.Models
{
    public partial class Swatch
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
        
        private string _colorCode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ColorCode
        {
            get { return this._colorCode; }
            set { this._colorCode = value; }
        }
        
        private string _colorName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ColorName
        {
            get { return this._colorName; }
            set { this._colorName = value; }
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
        
        private string _primaryHex;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PrimaryHex
        {
            get { return this._primaryHex; }
            set { this._primaryHex = value; }
        }
        
        private string _printGroup;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PrintGroup
        {
            get { return this._printGroup; }
            set { this._printGroup = value; }
        }
        
        private string _printImageUri;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PrintImageUri
        {
            get { return this._printImageUri; }
            set { this._printImageUri = value; }
        }
        
        private string _secondaryHex;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string SecondaryHex
        {
            get { return this._secondaryHex; }
            set { this._secondaryHex = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Swatch class.
        /// </summary>
        public Swatch()
        {
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
                JToken colorCodeValue = inputObject["colorCode"];
                if (colorCodeValue != null && colorCodeValue.Type != JTokenType.Null)
                {
                    this.ColorCode = ((string)colorCodeValue);
                }
                JToken colorNameValue = inputObject["colorName"];
                if (colorNameValue != null && colorNameValue.Type != JTokenType.Null)
                {
                    this.ColorName = ((string)colorNameValue);
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
                JToken primaryHexValue = inputObject["primaryHex"];
                if (primaryHexValue != null && primaryHexValue.Type != JTokenType.Null)
                {
                    this.PrimaryHex = ((string)primaryHexValue);
                }
                JToken printGroupValue = inputObject["printGroup"];
                if (printGroupValue != null && printGroupValue.Type != JTokenType.Null)
                {
                    this.PrintGroup = ((string)printGroupValue);
                }
                JToken printImageUriValue = inputObject["printImageUri"];
                if (printImageUriValue != null && printImageUriValue.Type != JTokenType.Null)
                {
                    this.PrintImageUri = ((string)printImageUriValue);
                }
                JToken secondaryHexValue = inputObject["secondaryHex"];
                if (secondaryHexValue != null && secondaryHexValue.Type != JTokenType.Null)
                {
                    this.SecondaryHex = ((string)secondaryHexValue);
                }
            }
        }
    }
}
