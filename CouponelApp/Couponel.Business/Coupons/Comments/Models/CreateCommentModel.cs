using System;
using System.Text.Json.Serialization;

namespace Couponel.Business.Coupons.Comments.Models
{
    public sealed class CreateCommentModel
    {
        public string Content { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
