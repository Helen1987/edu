// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {
        // Validation rules for the Album class

        [Bind(Exclude = "AlbumId")]
        public class AlbumMetaData
        {
            [ScaffoldColumn(false)]
            public object AlbumId { get; set; }

            [DisplayName("Genre")]
            public object GenreId { get; set; }

            [DisplayName("Artist")]
            public object ArtistId { get; set; }

            [Required(ErrorMessage = "An Album Title is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)] 
            [StringLength(160)]
            public object Title { get; set; }

            [DisplayName("Album Art URL")]
            [StringLength(1024)]
            public object AlbumArtUrl { get; set; }

            [Required(ErrorMessage = "Price is required")]
            [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
            public object Price { get; set; }
        }
    }
}