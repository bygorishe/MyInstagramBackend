﻿namespace Api.Models.Comment
{
    public class CreateCommentModel
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Caption { get; set; } = null!;
        public DateTimeOffset CreatedDate { get; set; }
    }

    public class CreateCommentRequest //в целом-то просто строка, надо ли класс отдельный?()(
    {
        public string Caption { get; set; } = null!;
    }
}