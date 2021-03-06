﻿namespace News.Api.Models.News
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateNewsRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}