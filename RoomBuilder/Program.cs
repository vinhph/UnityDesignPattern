using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBuilder
{
    public class Room
    {
        protected string Color { get; set; }
        public void SetColor(string color)
        {
            this.Color = color;
        }
    }
    public class BedRoom : Room
    {
        protected int NumberOfBeds { get; set; }
        public void SetNumberOfBeds(int num)
        {
            this.NumberOfBeds = num;
        }
    }
    public abstract class RoomBuilder<T, R>
        where T : RoomBuilder<T, R>
        where R : Room
    {
        protected R room;
        public T Paint()
        {
            room.SetColor("red");
            return Selft();
        }
        public abstract T Selft();
        public R Build()
        {
            return (R)room;
        }
    }
    public class BedRoomBuilder : RoomBuilder<BedRoomBuilder, BedRoom>
    {
        public BedRoomBuilder()
        {
            room = new BedRoom();
        }
        public BedRoomBuilder AddBed(int num)
        {
            room.SetNumberOfBeds(num);
            return Selft();
        }
        public override BedRoomBuilder Selft()
        {
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BedRoomBuilder bedRoomBuilder = new BedRoomBuilder();
            BedRoom bedRoom = bedRoomBuilder.Paint().AddBed(2).Build();
        }
    }
}
