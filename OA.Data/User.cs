﻿namespace OA.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
    }
}
