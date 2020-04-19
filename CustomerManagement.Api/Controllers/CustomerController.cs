using System.Net.Http;
using System.Web.Http;
using CSharpFunctionalExtensions;
using CustomerManagement.Api.Models;
using CustomerManagement.Logic.Model;
using CustomerManagement.Logic.Utils;

namespace CustomerManagement.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IEmailGateway _emailGateway;

        public CustomerController(UnitOfWork unitOfWork, IEmailGateway emailGateway):base(unitOfWork)
        {
            _customerRepository = new CustomerRepository(unitOfWork);
            _emailGateway = emailGateway;
        }

        [HttpPost]
        [Route("customers")]
        public HttpResponseMessage Create(CreateCustomerModel model)
        {
            var customerName = CustomerName.Create(model.Name);
            var primaryEmail = Email.Create(model.PrimaryEmail);
            var secondaryEmail = GetSecondaryEmail(model.SecondaryEmail);
            var industry = Industry.Get(model.Industry);

            var resultCombine = Result.Combine(customerName, primaryEmail, secondaryEmail, industry);
            if (resultCombine.IsFailure)
                return Error(resultCombine.Error);

            var customer = new Customer(customerName.Value,primaryEmail.Value, secondaryEmail.Value, industry.Value);
            _customerRepository.Save(customer);

            return Ok();
        }

        [HttpPut]
        [Route("customers/{id}")]
        public HttpResponseMessage Update(UpdateCustomerModel model)
        {
            Result<Customer> customerResult = _customerRepository.GetById(model.Id)
                .ToResult("Customer with such Id is not found: " + model.Id);
            Result<Industry> industryResult = Industry.Get(model.Industry);

            return Result.Combine(customerResult, industryResult)
                .OnSuccess(() => customerResult.Value.UpdateIndustry(industryResult.Value))
                .OnBoth(result => result.IsSuccess ? Ok() : Error(result.Error));
        }

        [HttpDelete]
        [Route("customers/{id}/emailing")]
        public HttpResponseMessage DisableEmailing(long id)
        {
            Maybe<Customer> customerOrNothing = _customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue)
                return Error("Customer with such Id is not found: " + id);

            Customer customer = customerOrNothing.Value;
            customer.DisableEmailing();

            return Ok();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public HttpResponseMessage Get(long id)
        {
            Maybe<Customer> customerOrNothing = _customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue)
                return Error("Customer with such Id is not found: " + id);

            Customer customer = customerOrNothing.Value;

            var model = new
            {
                customer.Id,
                Name = customer.Name.Value,
                PrimaryEmail = customer.PrimaryEmail.Value,
                SecondaryEmail = customer.SecondaryEmail.HasValue ? customer.SecondaryEmail.Value.Value : null,
                Industry = customer.EmailingSettings.Industry.Name,
                customer.EmailingSettings.EmailCampaign,
                customer.Status
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("customers/{id}/promotion")]
        public HttpResponseMessage Promote(long id)
        {
            return _customerRepository.GetById(id)
                .ToResult("Customer with such Id is not found: " + id)
                .Ensure(customer => customer.CanBePromoted(), "The customer not be promoted")
                .OnSuccess(customer => customer.Promote())
                .OnSuccess(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
                .OnBoth(result => result.IsSuccess ? Ok() : Error(result.Error));}

        private Result<Maybe<Email>> GetSecondaryEmail(string secondaryEmail)
        {
            if (secondaryEmail == null)
                return Result.Ok<Maybe<Email>>(null);

            return Email.Create(secondaryEmail).Map(secEmail => (Maybe<Email>)secEmail);
        }
    }
}
