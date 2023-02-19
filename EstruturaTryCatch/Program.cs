using EstruturaTryCatch.Entities;
using EstruturaTryCatch.Exceptions;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkin = DateTime.Parse(Console.ReadLine());

            Console.Write("Check-Out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(number, checkin, checkOut);
            Console.WriteLine("Reservatrion: " + reservation);

            Console.WriteLine();

            Console.WriteLine("Enter data to update the reservation: ");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkin = DateTime.Parse(Console.ReadLine());

            Console.Write("Check-Out date (dd/MM/yyyy): ");
            checkOut = DateTime.Parse(Console.ReadLine());

            reservation.UpadateDates(checkin, checkOut);
            Console.WriteLine("Reservation: " + reservation);
        }
        catch (DomainException e)
        {

            Console.WriteLine("Error in reservation: " + e.Message);
        }

    }
}