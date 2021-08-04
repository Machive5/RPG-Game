using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG_Game
{
	public class Program
	{
		static void Main(string[] args)
		{
			Play game = new Play();
			game.Name();
			
		}
	}

	public class Play
	{
		//item
		List<string> nitem = new List<string> { "Sword", "Head Armor", "Body Armor", "Leg Armor", "Healt Potion", "Mana Potion", "Atk Potion", "Def Potion" };
		List<int> jitem = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
		List<string> snitem = new List<string> { };
		List<int> sjitem = new List<int> { };
		List<int> price = new List<int> { 1000, 2000, 3000, 1500, 50, 50, 100, 100 };

		//equip condition
		List<string> equipment = new List<string> { };
		

		//base
		int A = 100;
		int D = 10;
		int H = 100;
		int M = 100;

		//stat indicator
		string name;
		int atk;
		int def;
		int hp;
		int mp;

		int at = 0;
		int dt = 0;
		int money;
		bool ondungeon;
		
		public void Name()
        {
			Console.WriteLine("WHAT'S YOUR NAME?");
			name = Console.ReadLine();
			Console.Clear();
			Menu();
        }

		public void Menu()
		{
			string a;
			Console.WriteLine("=============================================");
			Console.WriteLine("            MACHIVES SIMPLE RPG              ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("                 NEW GAME(Z)                 ");
			Console.WriteLine("                 EXIT(X)                     ");
			Console.WriteLine();
			Console.WriteLine("ENTER YOUR KEY...");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("=============================================");

			while(true)
			{
				a = Console.ReadLine();
				if (a == "z")
				{
					Console.Clear();
					Home();
					break;
				}

				else if (a == "x")
				{
					return;
				}

				else
				{
					Console.WriteLine("wrong input");
					continue;
				}
			}

			

		}

		public void Home()
		{
			string a;
			Stat_Editor();
			hp = H;
			mp = M;
			ondungeon = false;
			Console.Clear();
			Console.WriteLine("=============================================");
			Console.WriteLine("                   AT HOME                   ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("                 Profile (p)                 ");
			Console.WriteLine("                 Inventory (i)               ");
			Console.WriteLine("                 Dungeon (d)                 ");
			Console.WriteLine("                 Shop (S)                    ");
			Console.WriteLine("                 Back to Menu (b)            ");
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("ENTER YOUR KEY...");
			Console.WriteLine("=============================================");

			while(true)
			{
				a = Console.ReadLine();
				if (a == "p")
				{
					Console.Clear();
					Profile();
					break;
				}

				else if (a == "i")
				{
					Console.Clear();
					Inventory();
					break;
				}

				else if (a == "s")
				{
					Console.Clear();
					Shop();
					break;
				}

				else if (a == "d")
				{
					Console.Clear();
					Dungeon();
					break;
				}

				else if (a == "b")
				{
					Console.Clear();
					Menu();
					break;
				}

				else
				{
					Console.WriteLine("WRONG INPUT");
					continue;
				}
			}
		}

		public void	Inventory()
		{
			int a;
			int c;
			string f;
			string d;
			bool equiped;

			snitem.Clear();
			sjitem.Clear();

			for (int i = 0; i < nitem.Count; i++)
			{
				if (jitem[i] > 0)
				{
					sjitem.Add(jitem[i]);
					snitem.Add(nitem[i]);
				}
			}

			Console.WriteLine("=============================================");
			Console.WriteLine("                  INVENTORY                  ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			for (int b = 0; b < sjitem.Count; b++)
			{
				Console.WriteLine(b + 1 + "." + snitem[b] + " : " + sjitem[b]);
			}
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("TYPE THE NUMBER TO SHOW INFO...");
			Console.WriteLine("BACK(b)");
			Console.WriteLine("=============================================");
			
			while(true)
			{
				f = Console.ReadLine();

				if (f == "b")
				{
					Console.Clear();
					if (ondungeon == false)
                    {
						Home();
						break;
					}

                    else
                    {
						break;
                    }
					
				}

				if (int.TryParse(f, out a) == false)
				{
					Console.WriteLine("wrong input");
					continue;
				}

				a--;

				if (a + 1 <= snitem.Count && snitem.Count >= 0 && a >= 0)
				{

					for (c = 0; snitem[a] != nitem[c]; c++) ;

					Console.WriteLine("=============================================");
					Console.WriteLine("            WHAT YOU WANT TO DO?             ");
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("EQUIP(e)");
					Console.WriteLine("SELL(s)");
					Console.WriteLine("CANCEL(c)");
					Console.WriteLine();
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("=============================================");

					while(true)
					{
						equiped = false;
						d = Console.ReadLine();

						if (d == "s")
						{
							if (ondungeon == false)
                            {
								Console.WriteLine("HOW MUCH?");

								while (true)
								{
									f = Console.ReadLine();

									if (int.TryParse(f, out a) == false)
									{
										Console.WriteLine("wrong input");
										continue;
									}

									if (jitem[c] - a >= 0 && a >= 0)
									{
										money = money + price[c] * a * 30 / 100;
										jitem[c] = jitem[c] - a;
										Console.Clear();
										Inventory();

									}

									else
									{
										Console.WriteLine("wrong input");
										continue;

									}
								}
							}

							else
                            {
								Console.WriteLine("CAN'T SELLING IN DUNGEON ");
								continue;
                            }
							
						}

						else if (d == "e")
                        {
							for (int e = 0; e < equipment.Count; e++)
							{
								if (equipment[e] == snitem[a])
                                {
									equiped = true;
									break;
                                }
                            }

							if ( equiped == true )
							{
								Console.WriteLine(" THIS EQUIPMENT ALREADY EQUIPED");
								continue;
							}

							else
                            {
								if (snitem[a] == nitem[0] || snitem[a] == nitem[1] || snitem[a] == nitem[2] || snitem[a] == nitem[3])
                                {
									equipment.Add(nitem[c]);
								}

								else if(snitem[a] == nitem[6])
                                {
									at = 5;
                                }

								else if (snitem[a] == nitem[7])
								{
									dt = 5;
								}

								else if (snitem[a] == nitem[4])
                                {
									hp = hp + H * 60 / 100;
                                }

								else if (snitem[a] == nitem[5])
								{
									mp = mp + M * 60 / 100;
								}

								jitem[c] = jitem[c] - 1;
								Console.Clear();
								this.Stat_Editor();
								Inventory();
								break;
							}
						}

						else if( d == "c")
                        {
							Console.Clear();
							Inventory();
							break;
                        }

						else
						{
							Console.WriteLine("wrong input");
							continue;
						}
					} 

					break;
				}

				else
				{
					Console.WriteLine("WRONG INPUT");
					continue;
				} 


			}


		}

		public void Shop()
        {
			int g;
			int a;
			int b;
			string c;
			string d;
			List<string> item = nitem;
			
			Console.WriteLine("=============================================");
			Console.WriteLine("                     SHOP                    ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			for (g=0 ; g < item.Count; g++)
			{
				Console.WriteLine(g + 1 + ". " + item[g]);
			}
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("TYPE THE NUMBER OF ITEM TO BUY");
			Console.WriteLine("Back(b)");
			Console.WriteLine("=============================================");

			while(true)
			{
				c = Console.ReadLine();

				if (c == "b")
				{
					Console.Clear();
					Home();
					break;
				}

				if (int.TryParse(c, out a) == false)
				{
					Console.WriteLine("wrong input");
					continue;
				}
				
				a--;

				if (a + 1 <= item.Count && a >= 0)
				{
					Console.WriteLine("=============================================");
					Console.WriteLine("PRICE: " + price[a] + "/ITEM");
					Console.WriteLine("YOUR MONEY: " + money);
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("HOW MUCH YOU WANT TO BUY?");
					Console.WriteLine();
					Console.WriteLine("=============================================");
					Console.WriteLine("ENTER YOUR KEY...");
					Console.WriteLine("=============================================");

					
					while(true){
						d = Console.ReadLine();

						if (int.TryParse(d, out b) == false)
						{
							Console.WriteLine("wrong input");
							continue;
						}

						if (b >= 0)
                        {
							if (money - price[a] * b >= 0)
                            {
								money = money - price[a] * b;
								jitem[a] = jitem[a] + b;
								Console.Clear();
								Shop();
								break;
							}
                            else
                            {
								Console.WriteLine("NOT ENOUGH MONEY");
								continue;
								
                            }
							
                        }

                        else
                        {
							Console.WriteLine("wrong input");
							continue;
                        }

					}
				}

				else
				{
					Console.WriteLine("WRONG INPUT");
					continue;
				}

			}
		}

		public void Profile()
        {
			int a;
			string c;
			int i;
			Console.WriteLine("=============================================");
			Console.WriteLine("                  PROFILE                    ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("NAME: " + name);
			Console.WriteLine("HP: " + hp);
			Console.WriteLine("MP: " + mp);
			Console.WriteLine("ATK: " + atk);
			Console.WriteLine("DEF: " + def);
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("                  CONDITION                  ");
			Console.WriteLine("=============================================");
			Console.WriteLine();

			if(at > 0)
            {
				Console.WriteLine("BUFF: +40% ATK");
            }

			if(dt > 0)
			{
				Console.WriteLine("BUFF: +40% DEF");
			}

			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("                  EQUIPMENT                  ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			for (int b = 0; b< equipment.Count; b++)
            {
				Console.WriteLine(b + 1 + "." + equipment[b]);
            }
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine("TYPE THE NUMBER OF ITEM TO UNEQUIP");
			Console.WriteLine("BACK(b)");
			Console.WriteLine("=============================================");
			
			while(true){
				c = Console.ReadLine();

				if (c == "b")
				{
					Console.Clear();
					Home();
					break;
				}

				if (int.TryParse(c, out a) == false)
                {
					Console.WriteLine("wrong input");
					continue;
                }

				a--;

				if (a >= 0 && a+1 <= equipment.Count && equipment.Count >= 0)
                {
					for (i = 0; equipment[a] != nitem[i]; i++) ;
					equipment.Remove(equipment[a]);
					jitem[i] = jitem[i] + 1;
					Console.Clear();
					Stat_Editor();
					Profile();
					break;
				}

				else
                {
					Console.WriteLine("wrong input");
					continue;
                }
			} 
		}

		public void Stat_Editor()
		{
			atk = A;
			def = D;
			
			for (int f=0; f<equipment.Count; f++)
            {
				if (equipment[f] == nitem[0])
                {
					atk = atk + 100;
                }

				else if (equipment[f] == nitem[1])
				{
					def = def + 10;
				}

				else if (equipment[f] == nitem[2])
				{
					def = def + 30;
				}

				else if (equipment[f] == nitem[3])
				{
					def = def + 20;
				}

			}

			if (at > 0)
			{
				atk = atk + atk * 40/100;
			}

			if (dt > 0)
			{
				def = def + def * 40 / 100; 
			}

			if (hp > H)
            {
				hp = H;
            }

			if (mp > M)
            {
				mp = M;
            }

		}

		public void Dungeon()
        {
			string a;
			int rnd;

			ondungeon = true;
			Console.WriteLine("=============================================");
			Console.WriteLine("                  DUNGEON                    ");
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("                EXPLORE(e)                   ");
			Console.WriteLine("               INVENTORY(i)                  ");
			Console.WriteLine("              BACK TO HOME(b)                ");
			Console.WriteLine();
			Console.WriteLine("=============================================");
			Console.WriteLine();
			Console.WriteLine("=============================================");

			while(true)
            {
				a = Console.ReadLine();

				if (a == "e")
				{
					Console.Clear();
					Random rd = new Random();
					rnd = rd.Next(0, 5);

					if (rnd < 3)
					{
						Console.Clear();
						Battle(rnd);
						Console.Clear();
						Dungeon();
					}

					else if (rnd == 3)
					{
						Console.Clear();
						string e;
						Console.WriteLine("=============================================");
						Console.WriteLine("           YOU FOUND THE BOSS ROOM           ");
						Console.WriteLine("=============================================");
						Console.WriteLine();
						Console.WriteLine("                  ENTER(e)                   ");
						Console.WriteLine("            SKIP FOR THIS TIME(s)            ");
						Console.WriteLine();
						Console.WriteLine("=============================================");
						Console.WriteLine();
						Console.WriteLine("=============================================");

						while (true)
						{
							e = Console.ReadLine();
							if (e == "e")
							{
								Battle(rnd);
								Dungeon();
							}

							else if (e == "s")
							{
								Console.Clear();
								Dungeon();
							}

							else
							{
								Console.WriteLine("wrong input");
								continue;
							}
						}
					}

					else if (rnd == 4)
					{
						int[] chest = new int[3]{500,1000,2000};
						Random r = new Random();
						int f = r.Next(chest.Length);
						money = money + chest[f];

						Console.WriteLine("=============================================");
						Console.WriteLine("              YOU FOUND A CHEST              ");
						Console.WriteLine("=============================================");
						Console.WriteLine();
						Console.WriteLine("YOU GET " + chest[f] + " FROM THE CHEST");
						Console.WriteLine();
						Console.WriteLine("=============================================");
						Console.WriteLine("PRESS ANY KEY                                ");
						Console.WriteLine("=============================================");
						Console.ReadKey();
						Console.Clear();
						Dungeon();
					}
				}

				else if (a == "b")
				{
					Console.Clear();
					Home();
				}

				else if (a == "i")
                {
					Console.Clear();
					Inventory();
					Console.Clear();
					Dungeon();
                }

				else
                {
					Console.WriteLine("wrong input");
					continue;
                }
			}

			void Battle(int b)
			{
				List<string> monster = new List<string> { "SLIME", "GOBLIN", "OGRE", "DUNGEON QUEEN STATUE" };
				List<int> monsHP = new List<int> { 150, 250, 500, 1500 };
				List<int> monsATK = new List<int> { 15, 25, 50, 130 };
				List<int> gold = new List<int> { 200, 500, 1000 };
 
				int c = monsHP[b];
				string d;

				while(true)
                {
					Console.Clear();
					Console.WriteLine("=============================================");
					Console.WriteLine("               AN ENEMY'S APEAR              ");
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("MONSTER TYPE: " + monster[b]);
					Console.WriteLine("HP: " + c);
					Console.WriteLine();
					Console.WriteLine("----------------YOUR STATUS------------------");
					Console.WriteLine();
					Console.WriteLine("HP: " + hp);
					Console.WriteLine("MP:" + mp);
					if (at > 0)
					{
						Console.WriteLine("BUFF: +40% ATK");
					}

					if (dt > 0)
					{
						Console.WriteLine("BUFF: +40% DEF");
					}
					Console.WriteLine();
					Console.WriteLine("=============================================");
					Console.WriteLine("WHAT DO YOU WANT TO DO?                      ");
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("                  FIGHT(f)                   ");
					Console.WriteLine("                INVENTORY(i)                 ");
					Console.WriteLine("                   RUN(r)                    ");
					Console.WriteLine();
					Console.WriteLine("=============================================");
					Console.WriteLine();
					Console.WriteLine("=============================================");

					while(true)
                    {
						d = Console.ReadLine();
						if (d == "f")
                        {
							Random ran = new Random();
							int rand;
							string e;
							int f;
							Console.WriteLine("=============================================");
							Console.WriteLine("1. NORMAL ATK");
							Console.WriteLine("2. 3 TIMES SLASHING");
							Console.WriteLine();
							Console.WriteLine("=============================================");
							Console.WriteLine("TYPE THE NUMBER");
							Console.WriteLine("=============================================");

							while(true)
                            {
								e = Console.ReadLine();

								//you
								if (int.TryParse(e, out f) == false)
								{
									Console.WriteLine("wrong input");
									continue;
								}

								if (f == 2)
								{
									if (mp - 30 <= 0)
									{
										Console.WriteLine("not enough MP");
										continue;
                                    }

									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									mp = mp - 30;
									for (int g = 0; g < 3; g++)
									{
										rand = ran.Next(atk - 10, atk + 50);
										c = c - rand;
										Console.WriteLine(monster[b] + " dealed " + rand + "atk");
									}

									at--;
									dt--;

									if (c <= 0)
									{
										if (b == 3)
                                        {
											Console.Clear();
											Console.WriteLine("=============================================");
											Console.WriteLine("              CONGRANTULATION                ");
											Console.WriteLine("=============================================");
											Console.WriteLine();
											Console.WriteLine("       YOU DEFEATED THE BOSS DUNGEON         ");
											Console.WriteLine("       THANK YOU TO PLAYING THIS GAME        ");
											Console.WriteLine();
											Console.WriteLine("=============================================");
											Console.WriteLine("PRESS ANY KEY TO BACK TO EXIT...");
											Console.WriteLine("=============================================");
											Console.ReadKey();
											Environment.Exit(0);
										}
										money = money + gold[b];
										Console.WriteLine("=============================================");
										Console.WriteLine();
										Console.WriteLine("=============================================");
										Console.WriteLine();
										Console.WriteLine(monster[b] + " die.");
										Console.WriteLine("you got " + gold[b] + " money");
										Console.WriteLine();
										Console.WriteLine("=============================================");
										Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
										Console.WriteLine("=============================================");
										Stat_Editor();
										Console.ReadKey();
										Console.Clear();
										Dungeon();
									}

								}

								else if (f == 1)
								{
									rand = ran.Next(atk - 10, atk + 50);
									c = c - rand;
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine(monster[b] + " deal " + rand + "atk");
									at--;
									dt--;

									if (c <= 0)
									{
										if (b == 3)
										{
											Console.Clear();
											Console.WriteLine("=============================================");
											Console.WriteLine("              CONGRANTULATION                ");
											Console.WriteLine("=============================================");
											Console.WriteLine();
											Console.WriteLine("       YOU DEFEATED THE BOSS DUNGEON         ");
											Console.WriteLine("       THANK YOU TO PLAYING THIS GAME        ");
											Console.WriteLine();
											Console.WriteLine("=============================================");
											Console.WriteLine("PRESS ANY KEY TO BACK TO EXIT...");
											Console.WriteLine("=============================================");
											Console.ReadKey();
											Environment.Exit(0);
										}
										money = money + gold[b];
										Console.WriteLine("=============================================");
										Console.WriteLine();
										Console.WriteLine("=============================================");
										Console.WriteLine();
										Console.WriteLine(monster[b] + " die.");
										Console.WriteLine("you got " + gold[b] + " money");
										Console.WriteLine();
										Console.WriteLine("=============================================");
										Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
										Console.WriteLine("=============================================");
										Stat_Editor();
										Console.ReadKey();
										Console.Clear();
										Dungeon();
									}

								}

								else
								{
									Console.WriteLine("wrong input");
									continue;
								}

								break;
							}
							

							// monster
							rand = ran.Next(1, 2);
							if (c <= 0)
                            {
								break;
                            }

							if (rand == 1)
                            {
								rand = ran.Next(monsATK[b] - 10, monsATK[b] + 50);
								
								if (rand - def >= 0)
                                {
									hp = hp - (rand - def);
									Console.WriteLine();
									Console.WriteLine("MONSTER ATTACKING...");
									Console.WriteLine("you deal " + rand + "damage");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
								}

								else
                                {
									Console.WriteLine();
									Console.WriteLine("MONSTER ATTACKING...");
									Console.WriteLine("you deal 0 damage");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
								}

								if (hp <= 0)
                                {
									Console.Clear();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("                   YOU DIE                   ");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO BACK TO HOME...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
									Home();
								}

                            }

							else if (rand == 2)
                            {
								rand = ran.Next(monsATK[b]+30, monsATK[b] + 50);
								if (rand - def >= 0)
								{
									hp = hp - (rand - def);

									Console.WriteLine();
									Console.WriteLine("MONSTER ATTACKING...");
									Console.WriteLine("you deal " + rand + "damage");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
								}

								else
								{
									Console.WriteLine();
									Console.WriteLine("MONSTER ATTACKING...");
									Console.WriteLine("you deal 0 damage");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
								}

								if (hp <= 0)
								{
									Console.Clear();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine();
									Console.WriteLine("                   YOU DIE                   ");
									Console.WriteLine();
									Console.WriteLine("=============================================");
									Console.WriteLine("PRESS ANY KEY TO BACK TO HOME...");
									Console.WriteLine("=============================================");
									Console.ReadKey();
									Home();
								}
							}

							break;
						}

						else if(d == "i")
                        {
							Console.Clear();
							Inventory();
							Console.Clear();
							break;
                        }

						else if(d == "r")
                        {
							return;
                        }

						else
                        {
							continue;
                        }

                    }
					continue;
				}
				
			}
		}
	}
}


