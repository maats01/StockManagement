using AutoFixture;
using Entities;
using FluentAssertions;
using Moq;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace Tests
{
    public class ItemsServiceTests
    {
        private readonly IItemsService _itemsService;
        private readonly IFixture _fixture;
        private readonly IItemRepository _itemsRepository;
        private readonly Mock<IItemRepository> _itemsRepositoryMock;

        public ItemsServiceTests()
        {
            _fixture = new Fixture();

            _itemsRepositoryMock = new Mock<IItemRepository>();
            _itemsRepository = _itemsRepositoryMock.Object;

            _itemsService = new ItemsService(_itemsRepository);
        }

        public Item BuildExampleItem()
        {
            return _fixture.Create<Item>();
        }

        #region AddItem

        [Fact]
        public async Task AddItem_NullCreateDTO_ToThrowArgumentNullException()
        {
            ItemCreateDTO? itemCreateDTO = null;

            Func<Task> action = async () =>
            {
                await _itemsService.AddItem(itemCreateDTO);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddItem_ValidValues_ToBeSuccessful()
        {
            ItemCreateDTO? itemCreateDTO = _fixture.Create<ItemCreateDTO>();

            Item item = itemCreateDTO.ToItem();
            item.ID = 1;
            ItemDTO expected = item.ToItemDTO();

            _itemsRepositoryMock
                .Setup(t => t.AddItem(It.IsAny<Item>()))
                .ReturnsAsync(item);

            ItemDTO actual = await _itemsService.AddItem(itemCreateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetItems

        [Fact]
        public async Task GetItems_EmptyListByDefault()
        {
            List<Item> items = new();

            _itemsRepositoryMock
                .Setup(t => t.GetItems())
                .ReturnsAsync(items);

            List<ItemDTO> response = await _itemsService.GetItems();

            response.Should().BeEmpty();
        }

        [Fact]
        public async Task GetItems_NotEmpty()
        {
            List<Item> items = new List<Item>()
            {
                BuildExampleItem(), BuildExampleItem(), BuildExampleItem()
            };
            List<ItemDTO> expected = items.Select(t => t.ToItemDTO()).ToList();

            _itemsRepositoryMock
                .Setup(t => t.GetItems())
                .ReturnsAsync(items);

            List<ItemDTO> actual = await _itemsService.GetItems();

            actual.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetItemByID

        [Fact]
        public async Task GetItemByID_InvalidID_ToBeNull()
        {
            ItemDTO? response = await _itemsService.GetItemByID(55);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetItemByID_ValidID_ToBeSuccessful()
        {
            Item item = BuildExampleItem();
            ItemDTO expected = item.ToItemDTO();

            _itemsRepositoryMock
                .Setup(t => t.GetItemByID(It.IsAny<int>()))
                .ReturnsAsync(item);

            ItemDTO? actual = await _itemsService.GetItemByID(item.ID);

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region UpdateItem

        [Fact]
        public async Task UpdateItem_NullUpdateDTO_ToThrowArgumentNullException()
        {
            ItemUpdateDTO? itemUpdateDTO = null;

            Func<Task> action = async () => 
            { 
                await _itemsService.UpdateItem(itemUpdateDTO);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task UpdateItem_ValidUpdateDTO_ToBeSuccessful()
        {
            ItemUpdateDTO itemUpdateDTO = _fixture.Create<ItemUpdateDTO>();
            Item item = itemUpdateDTO.ToItem();
            ItemDTO expected = item.ToItemDTO();

            _itemsRepositoryMock
                .Setup(t => t.UpdateItem(It.IsAny<Item>()))
                .ReturnsAsync(item);

            ItemDTO actual = await _itemsService.UpdateItem(itemUpdateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region RemoveItem

        [Fact]
        public async Task UpdateItem_InvalidID_ToBeFalse()
        {
            bool isRemoved = await _itemsService.RemoveItem(55);

            isRemoved.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateItem_InvalidID_ToBeTrue()
        {
            Item item = BuildExampleItem();

            _itemsRepositoryMock
                .Setup(t => t.GetItemByID(It.IsAny<int>()))
                .ReturnsAsync(item);

            bool isRemoved = await _itemsService.RemoveItem(item.ID);

            isRemoved.Should().BeTrue();
        }

        #endregion
    }
}
