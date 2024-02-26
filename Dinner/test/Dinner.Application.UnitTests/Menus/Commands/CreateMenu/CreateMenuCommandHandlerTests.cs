using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Application.UnitTests.Menus.Extensions;
using Dinner.Application.UnitTests.TestUtils;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async void HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            var result = await _handler.Handle(createMenuCommand, default);

            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuCommand);
            _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };
            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(3)
                )
            };

            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateMenuItemCommand(3))
                )
            };
        }
    }
}
