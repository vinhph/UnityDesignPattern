using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No14_FacetedBuilder
{
    public class Ads
    {
        public string VIP1, VIP2;
        public string ToString()
        {
            return $"VIP1:{VIP1} And VIP2:{VIP2}";
        }
    }
    public class AdsBuilder
    {
        public Ads ads = new Ads();
        public AdsVIP1Builder Lives => new AdsVIP1Builder(ads);
        public AdsVIP2Builder Works => new AdsVIP2Builder(ads);

        public static implicit operator Ads(AdsBuilder pb)// mục đích nếu ép Ads ads = AdsBuilder thì sẽ lấy AdsBuilder.ads
        {
            return pb.ads;
        }
    }
    public class AdsVIP1Builder : AdsBuilder
    {
        public AdsVIP1Builder(Ads ads)
        {
            this.ads = ads;
        }
        public AdsVIP1Builder VIP1Create(string vip1)
        {
            this.ads.VIP1 = vip1;
            return this;
        }
    }
    public class AdsVIP2Builder : AdsBuilder
    {
        public AdsVIP2Builder(Ads ads)
        {
            this.ads = ads;
        }
        public AdsVIP2Builder VIP2Create(string vip2)
        {
            this.ads.VIP2 = vip2;
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var adsBuilder = new AdsBuilder();
            Ads ads = adsBuilder
                .Lives //trả về AdsVIP1Builder nên có property VIP1Create
                    .VIP1Create("1111111") //VIP1Create trả về AdsBuilder nên có .Works
                .Works //trả về AdsVIP2Builder nên có property VIP2Create
                    .VIP2Create("222222222");

            Console.WriteLine(ads.ToString());
            Console.ReadLine();
        }
    }
}
