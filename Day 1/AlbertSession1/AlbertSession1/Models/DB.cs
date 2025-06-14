using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

namespace AlbertSession1.Models
{
    
    public class DB
    {
        private static albertEntities1 context;
        


        public static albertEntities1 Gt()
        {
            if(context == null)
            {
                context = new albertEntities1();
            }
            return context;
        }


        public static void userBanChange(bool ban,string email) {
            var user = Gt().users.FirstOrDefault(a => a.email == email);
            if (ban)
            {
                if (user != null)
                {
                    user.IsBanned = true;
                }

            }
            else
            {
                
                if (user != null)
                {
                    user.IsBanned = false;
                }

            }
            Gt().SaveChanges();
        }
        public static List<@event> getEventsWithVenue()
        {
            var db = Gt();
            var @events = db.@event.Include("venue").ToList();
            return @events;
        }
        public static List<@event> getAllEvents()
        {
            var db = Gt();
            var eventsAll = new List<@event>();
            try
            {
                eventsAll = db.@event.Include("venue").ToList();
            }catch(Exception ex)
            {
                MessageBox.Show("Error while retriving events!" + ex.Message);
            }
            return eventsAll;
        }
        public static List<ContentUser> getAllUsers()
        {
            var db = Gt();
            var result = new List<ContentUser>();
            try
            {
                var users = db.users.ToList();
                var moderators = db.moderator.ToList();
                var organizers = db.organizer.ToList();

                foreach(var user in users)
                {
                    var org = organizers.FirstOrDefault(o => o.email == user.email);
                    if(org != null)
                    {
                        result.Add(new ContentUser { 
                            email = org.email,
                            firstName = org.pre_name,
                            familyName = org.family_name,
                            town_postalCode = org.Postal_code_and_town,
                            birthDay = org.birthday,
                            address = org.address,
                            phone =org.phone,
                            isBanned = user.IsBanned ?? false,

                        
                        });
                    }

                    var mod = moderators.FirstOrDefault(m => m.email == user.email);
                    if (mod != null)
                    {
                        result.Add(new ContentUser {
                            email = mod.email,
                            firstName = mod.given_name,
                            familyName = mod.family_name,
                            town_postalCode = mod.town,
                            birthDay = mod.birthday,
                            address = mod.street_number,
                            phone = mod.phone,
                            isBanned = user.IsBanned ?? false,
                        });
                    }
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
            return result;
        }



        public static void addModerator(string email,string password,string givenName,string familyName,string town,DateTime birtyhday,string postalCode,string streetNumber,string phone)
        {
            var db = Gt();
            try
            {
                db.moderator.Add(new moderator { 
                    email = email,
                    passwordm = password,
                    given_name = givenName,
                    family_name = familyName,
                    phone = phone,
                    birthday = birtyhday,
                    town = town,
                    postal_code = (short)int.Parse(postalCode),
                    street_number = streetNumber,

                
                });
            }catch(Exception ex)
            {
                MessageBox.Show("Error while adding new Moderator:" + ex.Message);
            }
        }


        public static bool LoginUser(string email, string password, out bool isModerator, out string message)
        {
            isModerator = false;
            message = string.Empty;

            var db = Gt();

            var user = db.users.FirstOrDefault(users => users.email == email);

            if (user == null)
            {
                message = "User was not found!";
                return false;
            }
            if (user.IsBanned == null || user.IsBanned == true)
            {
                message = "User is banned!";
                return false;
            }
            
            if (user.FailedAttempts >= 3)
            {
                var timeSinceLastFail = DateTime.Now - (user.LastFailedLogin ?? DateTime.MinValue);
                if (timeSinceLastFail.TotalSeconds < 10)
                {
                    int remaining = 10 - (int)timeSinceLastFail.TotalSeconds;
                    message = $"A lot of attempts for login, Plesae wait {remaining} seconds.";
                    return false;
                }
                else
                {
                    user.FailedAttempts = 0;
                    db.SaveChanges();

                }
            }


            if (user.passworduser != password)
            {
                user.FailedAttempts++;
                user.LastFailedLogin = DateTime.Now;
                db.SaveChanges();

                if (user.FailedAttempts >= 3)
                {
                    message = "A lot of attempts to login, Please wait 10 seconds";
                    return false;
                }
                else
                {
                    message = "Incorrect Password!";
                    return false;
                }


            }
            user.FailedAttempts = 0;
            user.LastFailedLogin = null;
            db.SaveChanges();
            if(user.is_moderator == null)
            {
                isModerator = false;
            }
            else if(user.is_moderator == 1)
            {
                isModerator = true;
            }
            else
            {
                isModerator = false;
            }
                message = "Login succeed";
            return true;
        }

        public static void SignUpUser(
        string email,
        string password,
        string preName,
        string familyName,
        string postalCode,
        DateTime birthDate,
        string address,
        string phone,
        string hobby)
        {
            var db = Gt();

            try
            {
            
                var organizer = new organizer
                {
                    email = email,
                    passwordo = password,
                    pre_name = preName,
                    family_name = familyName,
                    Postal_code_and_town = postalCode,
                    birthday = birthDate,
                    address = address,
                    phone = phone,
                    hobby = hobby,
                };

                db.organizer.Add(organizer);

                // Также создаем запись в таблице users
                var user = new users
                {
                    email = email,
                    passworduser = password,
                    is_moderator = 0,
                    IsBanned = false,
                    FailedAttempts = 0,
                    LastFailedLogin = null
                };

                db.users.Add(user);

                db.SaveChanges();
                MessageBox.Show("User successfully registered!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while signing up a new user!\n{ex.Message}");
            }
        }


    }
}
