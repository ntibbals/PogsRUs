using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class Payment
    {

        private IConfiguration _configuration;

        public Payment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Run()
        {

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["Auth_Api_ID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["Auth_Transaction_Key"]
            };

            var creditCardVisa = new creditCardType
            {
                cardNumber = "4007000000027",
                expirationDate = "1221"
            };
            var creditCardMaster = new creditCardType
            {
                cardNumber = "5424000000000015",
                expirationDate = "1121"
            };
            var creditCardDiscover = new creditCardType
            {
                cardNumber = "6011000000000012",
                expirationDate = "0921"
            };

            customerAddressType billingAddress = GetAddress();

            paymentType paymentType = new paymentType { Item = creditCardVisa };

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 104.75m,
                payment = paymentType,
                billTo = billingAddress
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };

            var controller = new createTransactionController(request);

            controller.Execute();

            var response = controller.GetApiResponse();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse != null)
                    {
                        return "Ok";
                    }

                }
                else
                {
                    return "Not OK";
                }
              }
                return "Not OK";
            }

            private customerAddressType GetAddress()
            {

                customerAddressType address = new customerAddressType()
                {
                    firstName = "first",
                    lastName = "Last",
                    address = "123",
                    city = "city",
                    zip = "zipcode"
                };

                return address;
            }

        private lineItemType[] GetLineItems(List<CartProduct> products)
        {
            lineItemType[] lineitems = new lineItemType[products.Count];

            int count = 0;

            foreach (var item in products)
            {
                lineitems[count] = new lineItemType
                {

                    itemId = "1",
                    name = "productName",
                    quantity = 2,
                    unitPrice = new decimal(3.50)
                };
                count++;
            }

            return lineitems;
        }
    }

 }

