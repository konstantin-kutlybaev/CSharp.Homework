using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Phonebook.Tests
{
    public class PhonebookTests
    {
        private Phonebook phonebook;
        private Subscriber subscriber;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.phonebook = new Phonebook();
        }

        [TearDown]
        public void TearDown()
        {
            this.phonebook.ClearPhonebookList();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.phonebook = null;
        }
        [Test]
        public void AddSubscriber_NewSubscriber_AddedSuccessfully()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());

            this.phonebook.AddSubscriber(expectedSubscriber);

            Assert.That(this.phonebook.GetSubscriber(subcriberId), Is.EqualTo(expectedSubscriber));
        }
        [Test]
        public void CreateSubscriber_WithEmptyId_ThrowsExceprion()
        {
            Guid subcriberId = Guid.Empty;
            string subcriberName = string.Empty;

            Assert.Throws<ArgumentNullException>(() => new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>()));
        }
        [Test]
        public void AddSubscriber_ShouldThrowException_WhenSubscriberExists()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());

            phonebook.AddSubscriber(expectedSubscriber);

            var exception = Assert.Throws<InvalidOperationException>(() => phonebook.AddSubscriber(expectedSubscriber));
            Assert.AreEqual("Unable to add subscriber. Subscriber exists", exception.Message);
        }
        [Test]
        public void GetSubscriber_ShouldReturnSubscriber_WhenSubscriberExists()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());
            phonebook.AddSubscriber(expectedSubscriber);

            var result = phonebook.GetSubscriber(expectedSubscriber.Id);
            Assert.AreEqual(expectedSubscriber, result);
        }
        [Test]
        public void GetSubscriber_ShouldThrowException_WhenSubscriberDoesNotExist()
        {
            var nonExistentId = Guid.NewGuid();
            Assert.Throws<InvalidOperationException>(() => phonebook.GetSubscriber(nonExistentId));
        }
        [Test]
        public void DeleteSubscriber_ShouldRemoveSubscriber_WhenSubscriberExists()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());
            phonebook.AddSubscriber(expectedSubscriber);

            phonebook.DeleteSubscriber(expectedSubscriber);

            var result = phonebook.GetAll().ToList();
            Assert.IsEmpty(result);
        }

        [Test]
        public void DeleteSubscriber_ShouldThrowException_WhenSubscriberDoesNotExist()
        {
            var nonExistentSubscriber = new Subscriber(Guid.NewGuid(), "Nonexistent Subscriber", new List<PhoneNumber>());

            var exception = Assert.Throws<InvalidOperationException>(() => phonebook.DeleteSubscriber(nonExistentSubscriber));
            Assert.AreEqual("Unable to delete subscriber. Subscriber does not exist", exception.Message);
        }

        [Test]
        public void RenameSubscriber_ShouldChangeName_WhenCalled()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());
            phonebook.AddSubscriber(expectedSubscriber);
            var newName = "Юлий Цезарь";

            phonebook.RenameSubscriber(expectedSubscriber, newName);

            var updatedSubscriber = phonebook.GetSubscriber(expectedSubscriber.Id);

            Assert.AreEqual(newName, updatedSubscriber.Name);
        }
        [Test]
        public void RenameSubscriber_WhenEmptyName_WhenCalled()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>());
            var newName = string.Empty;

            phonebook.AddSubscriber(expectedSubscriber);

            Assert.Throws<ArgumentNullException>(() => phonebook.RenameSubscriber(expectedSubscriber, newName));
        }

        [Test]
        public void AddNumberToSubscriber_AddPhoneNumberIncorrectFormat_WhenCalled()
        {
            Guid subcriberId = Guid.NewGuid();
            string subcriberName = "Константин";
            var phoneNumber = new PhoneNumber("ghfhgfhgfh", PhoneNumberType.Personal);
            var expectedSubscriber = new Subscriber(subcriberId, subcriberName, new List<PhoneNumber>() { phoneNumber });

            phonebook.AddSubscriber(expectedSubscriber);

            Assert.Throws<ArgumentException>(() => phonebook.AddNumberToSubscriber(expectedSubscriber, phoneNumber));
        }

        [Test]
        public void AddNumberToSubscriber_AddedSuccessfully_WhenCalled()
        {
            var subscriberId = Guid.NewGuid();
            var subscriberName = "Константин";
            var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
            var newPhoneNumber = new PhoneNumber("+7(912)333-4444", PhoneNumberType.Work);

            phonebook.AddSubscriber(expectedSubscriber);
            phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber);

            Assert.That(phonebook.GetSubscriber(subscriberId), Is.EqualTo(expectedSubscriber));
        }
        [Test]
        public void AddNumberToSubscriber_NumberIsEmpty_WhenCalled()
        {
            var subscriberId = Guid.NewGuid();
            var subscriberName = "Константин";
            var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
            var newPhoneNumber = new PhoneNumber(string.Empty, PhoneNumberType.Work);

            phonebook.AddSubscriber(expectedSubscriber);

            Assert.Throws<ArgumentException>(() => phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber));
        }

        [Test]
        public void ClearPhonebookList_ShouldRemoveAllSubscribers()
        {
            var subscriber1 = new Subscriber(Guid.NewGuid(), "Константин", new List<PhoneNumber>());
            var subscriber2 = new Subscriber(Guid.NewGuid(), "Александр Македонский", new List<PhoneNumber>());
            phonebook.AddSubscriber(subscriber1);
            phonebook.AddSubscriber(subscriber2);

            phonebook.ClearPhonebookList();

            var result = phonebook.GetAll().ToList();
            Assert.IsEmpty(result);
        }
    } 
}