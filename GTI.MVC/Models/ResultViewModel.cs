﻿namespace GTI.MVC.Models
{
    public class ResultViewModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
