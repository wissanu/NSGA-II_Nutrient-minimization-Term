using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimize.GA
{
    public partial class Form1 : Form
    {
        public double val_BMR, sum_exe, sum_exe_cal;
        public int meal_per_day, num_mainMenu, num_Dessert, num_Drink;
        public double test,index_chro;
        public static List<FoodList> food_lists = new List<FoodList>();
        public static Food call_food = new Food();
        public static List<FoodList> des_lists = new List<FoodList>();
        public static Food call_des = new Food();
        public static List<FoodList> drink_lists = new List<FoodList>();
        public static Food call_drink = new Food();
        public int lm ,mm, nn, om,position_Gene_Main,position_Gene_Dess,position_Gene_Drink, c_Chro = 0 , num_index_chromosome;
        List<string> nameDess1 = new List<string>();
        List<string> nameDrink1 = new List<string>();
        List<string> nameFood1 = new List<string>();
        List<string> nameDess2 = new List<string>();
        List<string> nameDrink2 = new List<string>();
        List<string> nameFood2 = new List<string>();
        List<string> nameDess3 = new List<string>();
        List<string> nameDrink3 = new List<string>();
        List<string> nameFood3 = new List<string>();
        public static string nameFood_list1, nameDess_list1, nameDrink_list1, nameFood_list2, nameDess_list2, nameDrink_list2, nameFood_list3, nameDess_list3, nameDrink_list3;
        public Form1()
        {
            InitializeComponent();
            // invoke object FoodList (i assign to invoke in main for cut-off the complexity of duplicate call)
            call_food.Foodsetobj(ref food_lists);
            call_des.Dessetobj(ref des_lists);
            call_drink.Drinksetobj(ref drink_lists);
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            int l = 0, m = 0, n = 0, o;
            int a, w, h;
            double cross_rate = 0, mutage_rate = 0;
            int pop_size = 0, gen_size = 0;
            List<double> execercise = new List<double>();

            a = int.Parse(textBox_age.Text);
            w = int.Parse(textBox_Wg.Text);
            h = int.Parse(textBox_Hg.Text);

            cross_rate = double.Parse(textBoxcrossrate.Text);
            mutage_rate = double.Parse(textBoxmutage.Text);
            pop_size = int.Parse(textBoxpop_size.Text);
            gen_size = int.Parse(textBoxgen_size.Text);

            // --------------- Part Cal BMR ----------------
            if (comboBoxGender.Text == "Male")
            {
                val_BMR = 66 + (13.7 * w) + (5 * h) - (6.8 * a);
            }
            else if (comboBoxGender.Text == "Female")
            {
                val_BMR = 665 + (9.6 * w) + (1.8 * h) - (4.7 * a);
            }

           

            //------------ Part Execercise ------------------
            if (checkBoxSit.Checked)
            {
                double sit = 100.0;
                execercise.Add(sit);
            }
            if (checkBoxWalk.Checked)

            {
                double walk = 300.0;
                execercise.Add(walk);
            }
            if(checkBoxAero.Checked)
            {
                double Aero = 600.0;
                execercise.Add(Aero);
            }
            if (checkBoxSwim.Checked)

            {
                double swim = 260.0;
                execercise.Add(swim);
            }
            if (checkBoxRope.Checked)
            {
                double rope = 780.0;
                execercise.Add(rope);
            }
            if (checkBoxBox.Checked)

            {
                double boxing = 800.0;
                execercise.Add(boxing);
            }
            if (checkBoxTennis.Checked)
            {
                double tennis = 360.0;
                execercise.Add(tennis);
            }
            if (checkBoxHoop.Checked)

            {
                double hoop = 400.0;
                execercise.Add(hoop);
            }
            if (checkBoxBas.Checked)
            {
                double bas = 360.0;
                execercise.Add(bas);
            }
            if (checkBoxBicycle.Checked)

            {
                double bic = 250.0;
                execercise.Add(bic);
            }

            
             sum_exe =execercise.Sum();

            string value1 = sum_exe.ToString();
            

            //--------------- sum exe+calorie
             sum_exe_cal = sum_exe + val_BMR;

            string value2 = sum_exe_cal.ToString();
            



            // --------------- Part Select All Menu meal ----------------
            //Meal per day
            

            if (comboBoxMealDay.Text == "1")
            {
                meal_per_day = 1;
            }
            else if (comboBoxMealDay.Text == "2")
            {
                meal_per_day = 2;
            }
            else if (comboBoxMealDay.Text == "3")
            {
                meal_per_day = 3;
            }

            //MainMenu
            if (comboBoxMainMenu.Text == "0")
            {
                num_mainMenu = 0;
            }
            else if (comboBoxMainMenu.Text == "1")
            {
                num_mainMenu = 1;
            }
            else if (comboBoxMainMenu.Text == "2")
            {
                num_mainMenu = 2;
            }
            else if (comboBoxMainMenu.Text == "3")
            {
                num_mainMenu = 3;
            }
            //Dessert
            if (comboBoxDessert.Text == "0")
            {
                num_Dessert = 0;
            }
            else if(comboBoxDessert.Text == "1")
            {
                num_Dessert = 1;
            }
            else if (comboBoxDessert.Text == "2")
            {
                num_Dessert = 2;
            }
            else if (comboBoxDessert.Text == "3")
            {
                num_Dessert = 3;
            }
            //Drink
            if(comboBoxDrink.Text =="1")
            {
                num_Drink = 1;
            }
            else if (comboBoxDrink.Text == "2")
            {
                num_Drink = 2;
            }
            //test fitness 
//----------------------------------------------------------------------------------
            if (meal_per_day == 1) //เลือกอาหาร 1 มือต่อวัน
            {
                //จำนวนอาหารจารหลัก
                if (num_mainMenu == 0) { l = 0; }
                else if (num_mainMenu == 1) { l = 1; position_Gene_Main = 1; }
                else if (num_mainMenu == 2) { l = 2; position_Gene_Main = 2; }
                else if (num_mainMenu == 3) { l = 3; position_Gene_Main = 3; }

                if (num_Dessert == 0) { m = 0; }
                else if (num_Dessert == 1) { m = 1; position_Gene_Dess = 1; }
                else if (num_Dessert == 2) { m = 2; position_Gene_Dess = 2; }
                else if (num_Dessert == 3) { m = 3; position_Gene_Dess = 3; }

                if (num_Drink == 1) { n = 1; position_Gene_Drink = 1; }
                else if (num_Drink == 2) { n = 2; position_Gene_Drink = 2; }
            }
                
            if (meal_per_day == 2)
            {
                //จำนวนอาหารจารหลัก
                if (num_mainMenu == 0) { l = 0; }
                else if (num_mainMenu == 1) { l = 1*2; position_Gene_Main = 1; }
                else if (num_mainMenu == 2) { l = 2*2; position_Gene_Main = 2; }
                else if (num_mainMenu == 3) { l = 3*2; position_Gene_Main = 3; }

                if (num_Dessert == 0) { m = 0; }
                else if (num_Dessert == 1) { m = 1*2; position_Gene_Dess = 1; }
                else if (num_Dessert == 2) { m = 2*2; position_Gene_Dess = 2; }
                else if (num_Dessert == 3) { m = 3*2; position_Gene_Dess = 3; }

                if (num_Drink == 1) { n = 1*2; position_Gene_Drink = 1; }
                else if (num_Drink == 2) { n = 2*2; position_Gene_Drink = 1; }

            }

            if (meal_per_day == 3)
            {
                //จำนวนอาหารจารหลัก
                if (num_mainMenu == 0) { l = 0; }
                else if (num_mainMenu == 1) { l = 1*3; position_Gene_Main = 1; }
                else if (num_mainMenu == 2) { l = 2*3; position_Gene_Main = 2; }
                else if (num_mainMenu == 3) { l = 3*3; position_Gene_Main = 3; }

                if (num_Dessert == 0) { m = 0; }
                else if (num_Dessert == 1) { m = 1*3; position_Gene_Dess = 1; }
                else if (num_Dessert == 2) { m = 2*3; position_Gene_Dess = 2; }
                else if (num_Dessert == 3) { m = 3*3; position_Gene_Dess = 3; }

                if (num_Drink == 1) { n = 1*3; position_Gene_Drink = 1; }
                else if (num_Drink == 2) { n = 2*3; position_Gene_Drink = 2; }
            }

            o = l + m + n;
            lm = l;
            mm = m;
            nn = n;
            om = lm + mm + nn;

            // crossover rate = 0.65 , mutation size = 0.02 , population size = 1000 , generation = 2000 (best for now)
            var timeStarted = DateTime.Now;

            BETGA.GA ga = new BETGA.GA(cross_rate, mutage_rate, pop_size, gen_size, o); 
            
            ga.FitnessFunction = new BETGA.GAFunction(GenAlgFcn);
            ga.FatFunction = new BETGA.GAFunction(GenAlgFat);
            ga.ProtienFunction = new BETGA.GAFunction(GenAlgProtien);
            ga.CarboFunction = new BETGA.GAFunction(GenAlgCarbo);
            ga.LaunchGA();
            ga.Elitism = true;

            var elapsedMs = DateTime.Now.Subtract(timeStarted).TotalSeconds;
            MessageBox.Show("Time passed : "+elapsedMs);

            if (ga.best_fitness == -100000)
            {
                MessageBox.Show("no way to gain the minimum calories per day greater than 0" + "\n");
            }
            else/*------------------------Output show here-----------------------------*/
            {
                string BMR = val_BMR.ToString();
                string gene = o.ToString();
                string best_fit = ga.best_fitness.ToString();
                var bes_chomo = string.Join(",", ga.best_chromosome);
                string bes_fat = ga.best_fat.ToString();
                string bes_pro = ga.best_protien.ToString();
                string bes_carbo = ga.best_carbo.ToString();
                // MessageBox.Show("Gene : " + gene + "\n" + "min_fitness : " + best_fit + "\n" + "chromosome : " + bes_chomo+"\n"+"fat : " + bes_fat + "\n" + "protein : " + bes_pro+"\n"+"run time : "+elapsedMs+" millisec");
                
                
                /*--------------Out Put:Main Food,Dessert,Drink  FOR  each MEAL-PER-DAY ---------------*/
                if(nameFood1.Any())
                    nameFood1.Clear();

                if (nameFood2.Any())
                    nameFood2.Clear();

                if (nameFood3.Any())
                    nameFood3.Clear();

                //------output mainfood
                for (int i = 0; i<l;i++)
                    {
                        index_chro = ga.best_chromosome[c_Chro];
                        num_index_chromosome= (int)index_chro;
                        
                        //แบ่งตาม meal per day 
                        if (meal_per_day == 1)
                        {   
                            nameFood1.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 2)
                        {   int Temp_meal = l / 2;
                            if (i < Temp_meal)
                                nameFood1.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameFood2.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 3)
                        {
                            int Temp_meal = l / 3;
                            if (i < Temp_meal)
                                nameFood1.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameFood2.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                            else
                                nameFood3.Add(((FoodList)food_lists[num_index_chromosome]).NameFood);
                        }
                            c_Chro++;
                    }

                //------output Dessert
                if (nameDess1.Any())
                    nameDess1.Clear();

                if (nameDess2.Any())
                    nameDess2.Clear();

                if (nameDess3.Any())
                    nameDess3.Clear();

                for (int i=0;i<m;i++)
                    {
                        index_chro = ga.best_chromosome[c_Chro];
                        num_index_chromosome = (int)index_chro;
                        //แบ่่งตาม meal_per_day
                        
                        //แบ่งตาม meal per day 
                        if (meal_per_day == 1)
                        {
                            nameDess1.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 2)
                        {   int Temp_meal = m / 2;
                            if (i < Temp_meal)
                                nameDess1.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameDess2.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 3)
                        {
                            int Temp_meal = m / 3;
                            if (i < Temp_meal)
                                nameDess1.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameDess2.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                            else
                                nameDess3.Add(((FoodList)des_lists[num_index_chromosome]).NameFood);
                        }


                      c_Chro++;
                    }

                //------output  Drink
                if (nameDrink1.Any())
                    nameDrink1.Clear();

                if (nameDrink2.Any())
                    nameDrink2.Clear();

                if (nameDrink3.Any())
                    nameDrink3.Clear();

                for (int i =0; i<n;i++)
                    {
                        index_chro = ga.best_chromosome[c_Chro];
                        num_index_chromosome = (int)index_chro;
                    
                        
                        //แบ่งตาม meal per day 
                        if (meal_per_day == 1)
                        {
                            nameDrink1.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 2)
                        {
                            int Temp_meal = n / 2;
                            if (i < Temp_meal)
                                nameDrink1.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameDrink2.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                        }
                        else if (meal_per_day == 3)
                        {
                            int Temp_meal = n / 3;
                            if (i < Temp_meal)
                                nameDrink1.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                            else if (i < Temp_meal + Temp_meal)
                                nameDrink2.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                            else
                                nameDrink3.Add(((FoodList)drink_lists[num_index_chromosome]).NameFood);
                        }
                    
                         c_Chro++;
                    }
                    
               
                    //clear value
                    
                    c_Chro = 0;l = 0; m = 0; n = 0; lm = 0; mm = 0; nn = 0; om=0;
                


                nameFood_list1 = string.Join(",", nameFood1);
                nameDess_list1 = string.Join(",", nameDess1);
                nameDrink_list1 = string.Join(",", nameDrink1);
                nameFood_list2 = string.Join(",", nameFood2);
                nameDess_list2 = string.Join(",", nameDess2);
                nameDrink_list2 = string.Join(",", nameDrink2);
                nameFood_list3 = string.Join(",", nameFood3);
                nameDess_list3 = string.Join(",", nameDess3);
                nameDrink_list3 = string.Join(",", nameDrink3);
           
                //------Show result
                if (meal_per_day == 1)
                {
                    label18.Text = nameFood_list1;
                    label28.Text = nameDess_list1;
                    label29.Text = nameDrink_list1;
                    label30.Text = "-";
                    label31.Text = "-";
                    label32.Text = "-";
                    label33.Text = "-";
                    label34.Text = "-";
                    label35.Text = "-";
                }
                else if (meal_per_day == 2)
                {
                    label18.Text = nameFood_list1;
                    label28.Text = nameDess_list1;
                    label29.Text = nameDrink_list1;
                    label30.Text = nameFood_list2;
                    label31.Text = nameDess_list2;
                    label32.Text = nameDrink_list2;
                    label33.Text = "-";
                    label34.Text = "-";
                    label35.Text = "-";
                }


                else if (meal_per_day == 3)
                {
                    label18.Text = nameFood_list1;
                    label28.Text = nameDess_list1;
                    label29.Text = nameDrink_list1;
                    label30.Text = nameFood_list2;
                    label31.Text = nameDess_list2;
                    label32.Text = nameDrink_list2;
                    label33.Text = nameFood_list3;
                    label34.Text = nameDess_list3;
                    label35.Text = nameDrink_list3;
                }



                    
                    
                    
                   //MessageBox.Show("Food: " + nameFood_list + "\n" + "Dess : " + nameDess_list + "\n" + "Drink : " + nameDrink_list + "\n");

                
                /*--------output best Protine Carbo Calorie--------------*/
                    label45.Text = BMR;
                    label47.Text = bes_carbo;
                    label49.Text = bes_pro;
                    label51.Text = bes_fat;
                    label37.Text = best_fit;
                    label39.Text = bes_chomo;  

            }
        }//button click
          public double GenAlgFcn(double[] values)
        {
            // calories
            double cx = 0.0;
            double cy = 0.0;
            double cz = 0.0;

            int lm_temp = lm;
            int mm_temp = mm;
            int nn_temp = nn;
            //change caloties to fat in here
            for (int i = 0; i < lm_temp; i++)
                cx += ((FoodList)food_lists[(int)values[i]]).Calories;

            for (int i = lm_temp; i < mm_temp + lm_temp; i++)
                cy += ((FoodList)des_lists[(int)values[i]]).Calories;

            for (int i = lm_temp + mm_temp; i < lm_temp + mm_temp + nn_temp; i++)
                cz += ((FoodList)drink_lists[(int)values[i]]).Calories;
            
            double sum_bmr_exe = sum_exe_cal;
            //change fitness function in here
            return ((cx + cy + cz) - sum_bmr_exe);
        }
        public double GenAlgFat(double[] values)
        {
            // fat
            double fx = 0.0;
            double fy = 0.0;
            double fz = 0.0;

            int lm_temp = lm;
            int mm_temp = mm;
            int nn_temp = nn;
            //change caloties to fat in here
            for (int i = 0; i < lm_temp; i++)
                fx += ((FoodList)food_lists[(int)values[i]]).Fat;

            for (int i = lm_temp; i < mm_temp + lm_temp; i++)
                fy += ((FoodList)des_lists[(int)values[i]]).Fat;

            for (int i = lm_temp + mm_temp; i < lm_temp + mm_temp + nn_temp; i++)
                fz += ((FoodList)drink_lists[(int)values[i]]).Fat;
            
            //change fitness function in here
            return fx + fy + fz;
        }
        public double GenAlgCarbo(double[] values)
        {
            //carbo
            double cax = 0.0;
            double cay = 0.0;
            double caz = 0.0;

            int lm_temp = lm;
            int mm_temp = mm;
            int nn_temp = nn;
            //change caloties to fat in here
            for (int i = 0; i < lm_temp; i++)
                cax += ((FoodList)food_lists[(int)values[i]]).Carbo;

            for (int i = lm_temp; i < mm_temp + lm_temp; i++)
                cay += ((FoodList)des_lists[(int)values[i]]).Carbo;

            for (int i = lm_temp + mm_temp; i < lm_temp + mm_temp + nn_temp; i++)
                caz += ((FoodList)drink_lists[(int)values[i]]).Carbo;
            
            //change fitness function in here
            return cax + cay + caz;
        }
        public double GenAlgProtien(double[] values)
        {
            // protien
            double px = 0.0;
            double py = 0.0;
            double pz = 0.0;

            int lm_temp = lm;
            int mm_temp = mm;
            int nn_temp = nn;
            //change caloties to fat in here
            for (int i = 0; i < lm_temp; i++)
                px += ((FoodList)food_lists[(int)values[i]]).Protine;

            for (int i = lm_temp; i < mm_temp + lm_temp; i++)
                py += ((FoodList)des_lists[(int)values[i]]).Protine;

            for (int i = lm_temp + mm_temp; i < lm_temp + mm_temp + nn_temp; i++)
                pz += ((FoodList)drink_lists[(int)values[i]]).Protine;
            
            //change fitness function in here
            return px + py + pz;
        }

    }
}
