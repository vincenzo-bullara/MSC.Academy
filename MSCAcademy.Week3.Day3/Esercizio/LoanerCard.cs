using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Esercizio
{
    public enum UserType
    {
        Regular,
        Supporter,
        Premium
    }
    [JsonObject]
    public class LoanerCard<T> : IEnumerable where T : ILoanItem
    {
        [JsonProperty]
        private List<T> items { get; set; }

        private string name;
        private string lastName;
        private int userCode;
        private DateTime signUpDate;
        private UserType typeOfUser;

        public string _Name { get { return name; } }
        public string _LastName { get { return lastName; } }
        public int _UserCode { get { return userCode; } }
        public DateTime _SignUpDate { get { return signUpDate; } }
        public UserType _TypeOfUser { get { return typeOfUser; } }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public LoanerCard()
        {
            this.items = new List<T>();
            this.name = "";
            this.userCode = 0;
            this.signUpDate = DateTime.MinValue;
            this.typeOfUser = UserType.Regular;
        }

        /// <summary>
        /// Adds an item to the list of items of the user. It sets an item to borrowed state if the input ID is already present in the list.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void LoanItem(T item)
        {
            foreach (var i in items)
            {
                if (i.id == item.id)
                {
                    if (i.status == ItemStatus.Borrowed)
                    {
                        Console.WriteLine("\n{0} already borrowed", i.id);
                        return;
                    }
                    else
                    {
                        i.status = ItemStatus.Borrowed;
                        Console.WriteLine("\n{0} status changed to borrowed", i.id);
                        return;
                    }
                }
            }
            Console.WriteLine(item.id + " successfully borrowed");
            item.status = ItemStatus.Borrowed;
            items.Add(item);

        }

        /// <summary>
        /// Sets an item to returned status.
        /// </summary>
        /// <param name="item">Item to return.</param>
        public void ReturnItem(T item)
        {
            foreach (var i in items)
            {
                if (i.id == item.id)
                {
                    if (i.status != ItemStatus.Returned)
                    {
                        i.status = ItemStatus.Returned;
                        Console.WriteLine("\n{0} successfully returned", i.id);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n{0} already returned!", i.id);
                        return;
                    }
                }
            }
            Console.WriteLine("\n{0} not found!", item.id);
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void ShowItems()
        {
            foreach (T book in items)
            {
                Console.WriteLine("Item : {0}", book.id);
                Console.WriteLine("Status : {0}", book.status.ToString());
                Console.WriteLine("\n");
            }
        }

        public List<T> GetItemsList()
        {
            List<T> iterativeDictionary = new List<T>();
            foreach (var item in items)
            {
                iterativeDictionary.Add(item);
            }
            return iterativeDictionary;
        }

        /// <summary>
        /// Setups the user's informations.
        /// </summary>
        /// <param name="nameInput">Name of the user.</param>
        /// <param name="lastNameInput">Last name of the user.</param>
        /// <param name="userCodeInput">Identifying code of the user.</param>
        /// <param name="signupDateInput">Date time of the user's signup which is generated on setup call.</param>
        /// <param name="typeOfUserInput">User's level of client plan.</param>
        /// <param name="typeOfUserInput">User's level of client plan.</param>
        public void SetupUser(string nameInput, string lastNameInput, int userCodeInput, DateTime signupDateInput, UserType typeOfUserInput)
        {
            this.name = nameInput;
            this.lastName = lastNameInput;
            this.userCode = userCodeInput;
            this.signUpDate = signupDateInput;
            this.typeOfUser = typeOfUserInput;
        }

        /// <summary>
        /// Returns the number of items stored in the user's item dictionary.
        /// </summary>
        /// <returns>Number of items inside the dictionary.</returns>
        public int GetItemsLength()
        {
            return items.Count();
        }
    }
}
