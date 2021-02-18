using System;
namespace retro_api
{
    public class CustomError
    {
        private string msg;
        private int status;


        public CustomError(string msg, int status)
        {
            this.msg = msg;
            this.status = status;
        }
    }
}
