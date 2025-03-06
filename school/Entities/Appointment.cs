namespace school.Entity
{
    public class Appointment
    {
        //public static int overCode = 1;
        public int Code { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int ClientId { get; set; }

        public Appointment()
        {
            //overCode++;
        }

        public Appointment(int code,DateOnly d, TimeOnly t, int c) //: this()
        {
            Code = code;
            Date = d;
            Time = t;
            ClientId = c;
            //Code = overCode;
        }
    }
}