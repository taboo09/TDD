using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Tickets.Data;
using Xunit;

namespace Tickets.Tests
{
    public class ReadDataFromFileTests
    {
        private readonly string _path = "../../../../Tickets/Data/Sample.txt";

        [Fact]
        public async Task GetData_ReturnTicketDataObbject_FromTxtFile()
        {
            var ticketsData = await ReadDataFromFile.GetData(_path);

            ticketsData.People.Should().Be(5);
            ticketsData.Windows.Should().Be(2);
            ticketsData.Destinations.Should().HaveCount(c => c == 3);
            ticketsData.PersonDestinations.Should().HaveCount(c => c == 5);
        }

        [Fact]
        public async Task PriceCalculation_ReturnsOutputObject_WhenGettingData()
        {
            var ticketsData = await ReadDataFromFile.GetData(_path);

            var output = App.PriceCalculation(ticketsData);

            var expectedWindowsList = new List<int>() { 1, 1, 2, 1, 1 };

            output.TotalPrice.Should().Be(49.2M);
            output.Windows.Should().HaveCount(c => c == ticketsData.People);
            output.Windows.Should().BeEquivalentTo(expectedWindowsList);
        }
    }
}