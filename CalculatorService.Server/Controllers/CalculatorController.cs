using CalculatorService.Server.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculatorService.Server.Controllers
{
    public class CalculatorController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [ActionName("add")]
        public AddResponse add([FromBody]AddRequest value)
        {
            logger.Trace("Service called: add");

            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */
            if (value.Addends == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                AddResponse result = new AddResponse();

                // Execute operation: Add
                String forJournal = "";
                foreach (int number in value.Addends)
                {
                    result.Sum += number;
                    forJournal += number + " + ";
                }

                forJournal = forJournal.Substring(0, forJournal.Length - 1);
                forJournal += " = " + result.Sum;

                if (Request != null && Request.Headers != null)
                {
                    var headers = Request.Headers;

                    if (headers.Contains("X-Evi-Tracking-Id"))
                    {
                        // Must store this request’s details inside it’s journal
                        string trackingId = headers.GetValues("X-Evi-Tracking-Id").First();
                        logger.Info("X-Evi-Tracking-Id = " + trackingId);

                        Operation operation = new Operation
                        {
                            OperationDes = "Sum",
                            Calculation = forJournal,
                            Date = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")
                        };

                        Journal.store(int.Parse(trackingId), operation);
                        logger.Trace("Add success!!");
                    }                 
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("sub")]
        public SubResponse sub([FromBody]SubRequest value)
        {
            logger.Trace("Service called: Sub");

            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */
            if (value.Minuend == null || value.Subtrahend == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                SubResponse result = new SubResponse();

                // Execute operation: Sub
                String forJournal = "";

                result.Difference = value.Minuend - value.Subtrahend;
                forJournal = value.Minuend + " - " + value.Subtrahend + " = " + result.Difference;

                
                if (Request != null && Request.Headers != null)
                {
                    var headers = Request.Headers;

                    if (headers.Contains("X-Evi-Tracking-Id"))
                    {
                        // Must store this request’s details inside it’s journal
                        string trackingId = headers.GetValues("X-Evi-Tracking-Id").First();
                        logger.Info("X-Evi-Tracking-Id = " + trackingId);

                        Operation operation = new Operation
                        {
                            OperationDes = "Sub",
                            Calculation = forJournal,
                            Date = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")
                        };

                        Journal.store(int.Parse(trackingId), operation);
                        logger.Trace("Sub success!!");
                    }
                }              

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("mult")]
        public MultResponse mult([FromBody]MultRequest value)
        {
            logger.Trace("Service called: mult");

            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */
            if (value.Factors == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                MultResponse result = new MultResponse();

                // Execute operation: Mult

                String forJournal = "";
                result.Product = 1;
                foreach (int number in value.Factors)
                {
                    result.Product *= number;
                    forJournal += number + " * ";
                }

                forJournal = forJournal.Substring(0, forJournal.Length - 1);
                forJournal += " = " + result.Product;

                if (Request != null && Request.Headers != null)
                {
                    var headers = Request.Headers;

                    if (headers.Contains("X-Evi-Tracking-Id"))
                    {
                        // Must store this request’s details inside it’s journal
                        string trackingId = headers.GetValues("X-Evi-Tracking-Id").First();
                        logger.Info("X-Evi-Tracking-Id = " + trackingId);

                        Operation operation = new Operation
                        {
                            OperationDes = "Mult",
                            Calculation = forJournal,
                            Date = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")
                        };

                        Journal.store(int.Parse(trackingId), operation);
                        logger.Trace("Mult success!!");
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("div")]
        public DivResponse div([FromBody]DivRequest value)
        {
            logger.Trace("Service called: div");

            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */

            if (value == null || value.Dividend == null || value.Divisor == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                DivResponse result = new DivResponse();

                // Execute operation: Sub
                String forJournal = "";

                result.Quotient = value.Dividend / value.Divisor;
                result.Remainder = value.Dividend % value.Divisor;
                forJournal = value.Dividend + " / " + value.Divisor + " = " + result.Quotient  + " remainder = " + result.Remainder;


                if (Request != null && Request.Headers != null)
                {
                    var headers = Request.Headers;

                    if (headers.Contains("X-Evi-Tracking-Id"))
                    {
                        // Must store this request’s details inside it’s journal
                        string trackingId = headers.GetValues("X-Evi-Tracking-Id").First();
                        logger.Info("X-Evi-Tracking-Id = " + trackingId);

                        Operation operation = new Operation
                        {
                            OperationDes = "Div",
                            Calculation = forJournal,
                            Date = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")
                        };

                        Journal.store(int.Parse(trackingId), operation);
                        logger.Trace("Div success!!");
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("sqrt")]
        public SqrtResponse sqrt([FromBody]SqrtRequest value)
        {
            logger.Trace("Service called: sqrt");

            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */
            if (value.Number == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                SqrtResponse result = new SqrtResponse();

                // Execute operation: Sub
                String forJournal = "";

                result.Square = Math.Sqrt(value.Number);
                forJournal = "√" + value.Number + " = " + result.Square;


                if (Request != null && Request.Headers != null)
                {
                    var headers = Request.Headers;

                    if (headers.Contains("X-Evi-Tracking-Id"))
                    {
                        // Must store this request’s details inside it’s journal
                        string trackingId = headers.GetValues("X-Evi-Tracking-Id").First();
                        logger.Info("X-Evi-Tracking-Id = " + trackingId);

                        Operation operation = new Operation
                        {
                            OperationDes = "Sqrt",
                            Calculation = forJournal,
                            Date = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")
                        };

                        Journal.store(int.Parse(trackingId), operation);
                        logger.Trace("Sqrt success!!");
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("query")]
        public QueryResponse query([FromBody]QueryRequest value)
        {
            /* An invalid request has been received. 
            * This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
            * */
            if (value.Id == null)
            {
                logger.Error(HttpStatusCode.BadRequest);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                logger.Trace("Service called: query");

                QueryResponse result = new QueryResponse();
                //Get Operations for a id.
                result.Operations =  Journal.get(value.Id);

                if (result.Operations.Count() == 0)
                {
                    logger.Info("There isn't  Operations for the Id : + " + value.Id.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                /*
                 * An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support
                 * */
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }
    }
}
