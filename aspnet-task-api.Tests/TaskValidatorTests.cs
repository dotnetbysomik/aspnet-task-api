using aspnet_task_api.DTOs;
using aspnet_task_api.Validators;

namespace aspnet_task_api.Tests
{
    public class TaskValidatorTests
    {
        [Fact]
        public void TaskCreateValidator_Should_Fail_When_Title_Is_Empty()
        {
            var validator = new TaskCreateValidator();
            var dto = new TaskCreateDto { Title = "" };

            var result = validator.Validate(dto);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskCreateDto.Title));
        }

        [Fact]
        public void TaskCreateValidator_Should_Pass_When_Title_And_No_DueDate_Are_Valid()
        {
            var validator = new TaskCreateValidator();
            var dto = new TaskCreateDto { Title = "Buy groceries" };

            var result = validator.Validate(dto);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TaskUpdateValidator_Should_Fail_When_Id_Is_Zero()
        {
            var validator = new TaskUpdateValidator();
            var dto = new TaskUpdateDto { Id = 0, Title = "Valid Title" };

            var result = validator.Validate(dto);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskUpdateDto.Id));
        }
    }
}
