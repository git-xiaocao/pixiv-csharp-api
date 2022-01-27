using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class CommentsDTO : IPixivListData
    {
        public List<CommentEntity> Comments { get; set; } = default!;

        public string? NextUrl { get; set; }
    }
}
