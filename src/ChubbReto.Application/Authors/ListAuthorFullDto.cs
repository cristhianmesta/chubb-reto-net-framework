using System;

namespace ChubbReto.Application.Authors
{
    public class ListAuthorFullDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BithDate { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }
    }
}