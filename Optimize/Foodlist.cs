using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimize.GA
{
    public class Food
    {
        
        public FoodList Food1 = new FoodList()
        {
            Gene = "000",
            NameFood = "ส้มตำไทยใส่ปู",
            Calories = 297.5,
            Protine = 12.9,
            Carbo = 44.8,
            Fat = 7.3

        };

        public FoodList Food2 = new FoodList()
        {
            Gene = "001",
            NameFood = "ข้าวก้องหอมมะลิ",
            Calories = 366.0,
            Protine = 7.0,
            Carbo = 79.1,
            Fat = 2.4

        };
        public FoodList Food3 = new FoodList()
        {
            Gene = "010",
            NameFood = "ไข่เจียว",
            Calories = 200.0,
            Protine = 6.5,
            Carbo = 0.4,
            Fat = 7.3

        };

        public FoodList Food4 = new FoodList()
        {
            Gene = "011",
            NameFood = "ข้าวผัดหมูใส่ไข่",
            Calories = 560.7,
            Protine = 15.1,
            Carbo = 64.2,
            Fat = 26.4

        };
        public FoodList Food5 = new FoodList()
        {
            Gene = "100",
            NameFood = "เเกงไตปลา",
            Calories = 74.8,
            Protine = 10.56,
            Carbo = 6.6,
            Fat = 0.6

        };
        public FoodList Food6 = new FoodList()
        {
            Gene = "101",
            NameFood = "ข้าวเหนียว",
            Calories = 231,
            Protine = 4.1,
            Carbo = 0.6,
            Fat = 52.3

        };
        public FoodList Food7 = new FoodList()
        {
            Gene = "110",
            NameFood = "ข้าวหมกไก่",
            Calories = 499.2,
            Protine = 205.7,
            Carbo = 85.0,
            Fat = 10.4

        };
        public FoodList Food8 = new FoodList()
        {
            Gene = "110",
            NameFood = "แกงมัสหมั่นเนื้อ",
            Calories = 630.0,
            Protine = 25.5,
            Carbo = 0.0,
            Fat = 58.5

        };
        public FoodList Food9 = new FoodList()
        {
            Gene = "110",
            NameFood = "ข้าวโอ๊ต",
            Calories = 381.0,
            Protine = 10.8,
            Carbo = 71.2,
            Fat = 5.9

        };
        public FoodList Food10 = new FoodList()
        {
            Gene = "110",
            NameFood = "แกงผักกาดจอ",
            Calories = 140.0,
            Protine = 7.0,
            Carbo = 10.7,
            Fat = 8.0

        };

        public FoodList Dess1 = new FoodList()
        {
            Gene = "000",
            NameFood = "บราวนี่",
            Calories = 280.0,
            Protine = 3.7,
            Carbo = 30.1,
            Fat = 17.5

        };
        public FoodList Dess2 = new FoodList()
        {
            Gene = "001",
            NameFood = "โยเกิตผลไม้",
            Calories = 140.0,
            Protine = 3.0,
            Carbo = 25.0,
            Fat = 4.0

        };
        public FoodList Dess3 = new FoodList()
        {
            Gene = "010",
            NameFood = "กล้วยหอม",
            Calories = 105.0,
            Protine = 1.0,
            Carbo = 27.0,
            Fat = 0.0

        };
        public FoodList Dess4 = new FoodList()
        {
            Gene = "011",
            NameFood = "เเตงโม",
            Calories = 45.0,
            Protine = 1.7,
            Carbo = 21.6,
            Fat = 0.4

        };
        public FoodList Dess5 = new FoodList()
        {
            Gene = "100",
            NameFood = "แคนตาลูป",
            Calories = 86.0,
            Protine = 0.5,
            Carbo = 4.8,
            Fat = 0.1

        };
        public FoodList Dess6 = new FoodList()
        {
            Gene = "100",
            NameFood = "คอนเน่",
            Calories = 525.0,
            Protine = 4.9,
            Carbo = 55.9,
            Fat = 31.3

        }; public FoodList Dess7 = new FoodList()
        {
            Gene = "100",
            NameFood = "โปเต้",
            Calories = 517.0,
            Protine = 2.2,
            Carbo = 60.1,
            Fat = 29.8

        };
        public FoodList Dess8 = new FoodList()
        {
            Gene = "100",
            NameFood = "ฮานามิ",
            Calories = 490.0,
            Protine = 7,
            Carbo = 62.7,
            Fat = 23.5

        };
        public FoodList Dess9 = new FoodList()
        {
            Gene = "100",
            NameFood = "ลอดช่องน้ำกะทิ",
            Calories = 270.0,
            Protine = 1.6,
            Carbo = 28.2,
            Fat = 7.2

        };
        public FoodList Dess10 = new FoodList()
        {
            Gene = "100",
            NameFood = "ขนมลูกชุบ",
            Calories = 284.0,
            Protine = 6.6,
            Carbo = 49.5,
            Fat = 6.6

        };

        public FoodList Drink1 = new FoodList()
        {
            Gene = "000",
            NameFood = "ชาเขียวมะลิรสหวาน",
            Calories = 120.0,
            Protine = 0.0,
            Carbo = 30.0,
            Fat = 0.0

        };
        public FoodList Drink2 = new FoodList()
        {
            Gene = "001",
            NameFood = "นมถั่วเหลือง",
            Calories = 72.0,
            Protine = 2.4,
            Carbo = 8.6,
            Fat = 3.1

        };
        public FoodList Drink3 = new FoodList()
        {
            Gene = "010",
            NameFood = "ชาเขียวรสจืด",
            Calories = 0.0,
            Protine = 0.0,
            Carbo = 0.0,
            Fat = 0.0

        };
        public FoodList Drink4 = new FoodList()
        {
            Gene = "011",
            NameFood = "นมสด",
            Calories = 60.0,
            Protine = 4.0,
            Carbo = 7.0,
            Fat = 2.0

        };
        public FoodList Drink5 = new FoodList()
        {
            Gene = "100",
            NameFood = "น้ำส้มเเมนดาริน100% ",
            Calories = 100.0,
            Protine = 0.0,
            Carbo = 25.0,
            Fat = 0.0

        };

        public FoodList Drink6 = new FoodList()
        {
            Gene = "110",
            NameFood = "น้ำเเอ็ปเปิ้ลเเดง",
            Calories = 100.0,
            Protine = 0.0,
            Carbo = 25.0,
            Fat = 0.0
        };

        public FoodList Drink7 = new FoodList()
        {
            Gene = "111",
            NameFood = "จับเลี้ยง",
            Calories = 120.0,
            Protine = 0.0,
            Carbo = 29.0,
            Fat = 0.0
        };

        public void Foodsetobj(ref List<FoodList> obj)
        {
            List<FoodList> listFoods = new List<FoodList>();
            listFoods.Add(Food1);
            listFoods.Add(Food2);
            listFoods.Add(Food3);
            listFoods.Add(Food4);
            listFoods.Add(Food5);
            listFoods.Add(Food6);
            listFoods.Add(Food7);
            listFoods.Add(Food8);
            listFoods.Add(Food9);
            listFoods.Add(Food10);
            obj = listFoods;
        }

        public void Dessetobj(ref List<FoodList> obj)
        {
            List<FoodList> listDess = new List<FoodList>();
            listDess.Add(Dess1);
            listDess.Add(Dess2);
            listDess.Add(Dess3);
            listDess.Add(Dess4);
            listDess.Add(Dess5);
            listDess.Add(Dess6);
            listDess.Add(Dess7);
            listDess.Add(Dess8);
            listDess.Add(Dess9);
            listDess.Add(Dess10);
            obj = listDess;
        }

        public void Drinksetobj(ref List<FoodList> obj)
        {
            List<FoodList> listDrinks = new List<FoodList>();
            listDrinks.Add(Drink1);
            listDrinks.Add(Drink2);
            listDrinks.Add(Drink3);
            listDrinks.Add(Drink4);
            listDrinks.Add(Drink5);
            listDrinks.Add(Drink6);
            listDrinks.Add(Drink7);
            obj = listDrinks;
        }


        /*foreach (FoodList f in listFoods)
        {
            Console.WriteLine("Gene = {0}, Food = {1} , Calories = {2} , Protine={3},Carbo={4},Fat={5}", f.Gene, f.NameFood, f.Calories, f.Protine, f.Carbo, f.Fat);
        }*/

    }

}

//main
//class

public class FoodList
{
    public string Gene { get; set; }
    public string NameFood { get; set; }
    public double Calories { get; set; }
    public double Protine { get; set; }
    public double Carbo { get; set; }
    public double Fat { get; set; }
}




