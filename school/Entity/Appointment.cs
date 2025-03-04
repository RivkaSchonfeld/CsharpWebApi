namespace school.Entity
{
    public class Appointment
    {

        public static int overCode = 1;
        public int Code { get; set; }
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public Client Client { get; set; }
        public Appointment(DateOnly d, TimeOnly t, Client c)
        {

            Code = overCode++;
            Date = d;
            Time = t;

        }


    }
}
