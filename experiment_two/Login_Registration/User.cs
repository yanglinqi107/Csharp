using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Login_Registration
{
    class User
    {
        public String name;
        public String password;
        public String gender;
        public String major;

        public User()
        {
            name = "";
            password = "";
            gender = "";
            major = "";
        }

        public bool IsUserExit(String str)
        {
            try
            {
                FileStream fr = new FileStream("E:\\Csharp\\experiment_two\\Login_Registration\\user.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fr);
                int i = 0;
                String sname = "";
                while ((sname = sr.ReadLine()) != null) 
                {
                    ++i;
                    i = i % 4;
                    if (i == 1 && str == sname) 
                    {
                        sr.Close();
                        fr.Close();
                        return true;
                    }
                }
                sr.Close();
                fr.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public int IsUserExit(String name,String spass)
        {
            try
            {
                FileStream fr = new FileStream("E:\\Csharp\\experiment_two\\Login_Registration\\user.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fr);
                int i = 0;
                String sname = "";
                while ((sname = sr.ReadLine()) != null)
                {
                    ++i;
                    i = i % 4;
                    if (i == 1 && name == sname)
                    {
                        if (sr.ReadLine() == spass)
                        {
                            sr.Close();
                            fr.Close();
                            return 0;
                        }
                        else
                        {
                            sr.Close();
                            fr.Close();
                            return 1;
                        }
                    }
                }
                sr.Close();
                fr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 2;

        }
        public bool SaveUser()
        {
            try 
            {
                FileStream fw = new FileStream("E:\\Csharp\\experiment_two\\Login_Registration\\user.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fw);
                sw.WriteLine(this.name);
                sw.WriteLine(this.password);
                sw.WriteLine(this.gender);
                sw.WriteLine(this.major);
                sw.Close();
                fw.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return false;
        }
    }
}
