﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Text;
using CookComputing.XmlRpc;

namespace InfusionSoftDotNet
{
    class isdnAPI
    {
        public static string _AppName = ConfigurationSettings.AppSettings["iSdk-AppName"];
        public static string _AppType = ConfigurationSettings.AppSettings["iSdk-AppType"];
        public static string _ApiKey = ConfigurationSettings.AppSettings["iSdk-ApiKey"];
        public static string _ApiURL = String.Format("https://{0}.{1}.com/api/xmlrpc",
            _AppName,
            (_AppType == "m" ? "mortgageprocrm" : "infusionsoft"));

        #region Utilities
        /// <summary>
        /// appEcho will return the string that you pass to it back from the InfusionSoft server. Good for testing your connectivity to the server.
        /// </summary>
        /// <param name="textToEcho">String to be echoed back to you</param>
        /// <returns>A string that is identical to the string you passed to this method.</returns>
        public static string appEcho(string textToEcho)
        {
            string return_value = null;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                return_value = api.appEcho(textToEcho);
            }
            catch (Exception ex)
            {
                return_value = String.Format("Error: Unable to echo server.<br />{0}<br />",
                    ex.Message);
            }

            return return_value;
        }

        #endregion

        #region ContactService
        #region Core methods
        public static Int32 add(XmlRpcStruct cMap)
        {
            Int32 ret_value = 0;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addCon(_ApiKey, cMap);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static XmlRpcStruct[] findByEmail(string email, string[] returnFields)
        {
            XmlRpcStruct[] retArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retArray = api.findByEmail(_ApiKey, email, returnFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retArray = retFail;
            }
            return retArray;
        }

        public static XmlRpcStruct load(int Id, string[] selectedFields)
        {
            XmlRpcStruct retContact;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retContact = api.load(_ApiKey, Id, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                retContact = fail;
            }
            return retContact;
        }
        #endregion

        #region Follow up sequence methods
        public static bool addToCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addToCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static int getNextCampaignStep(int contactId, int campaignId)
        {
            int ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.getNextCampaignStep(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static bool pauseCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.pauseCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static bool removeFromCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.removeFromCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static bool resumeCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.resumeCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static int rescheduleCampaignStep(Array contactIds, int campaignStepId)
        {
            int ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.rescheduleCampaignStep(_ApiKey, contactIds, campaignStepId);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }
        #endregion

        #region Tag methods
        public static bool addToGroup(int contactId, int groupId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addToGroup(_ApiKey, contactId, groupId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static bool removeFromGroup(int contactId, int groupId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.removeFromGroup(_ApiKey, contactId, groupId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }
        #endregion

        #region Action methods
        // TODO - MJG - gotta figure out the equivalent of *struct params in .Net
        //public XmlRpcStruct runActionSequence(int contactId, int actionSequenceID, *struct params)
        #endregion
        #endregion

        #region DataService
        public static Int32 dsAdd(string table, XmlRpcStruct values)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAdd(_ApiKey, table, values);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static XmlRpcStruct dsLoad(string table, int Id, string[] fields)
        {
            XmlRpcStruct retStruct;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStruct = api.dsLoad(_ApiKey, table, Id, fields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                retStruct = fail;
            }
            return retStruct;
        }

        public static Int32 dsUpdate(string table, Int32 Id, XmlRpcStruct fields)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsUpdate(_ApiKey, table, Id, fields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static Boolean dsDelete(string table, Int32 Id)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsDelete(_ApiKey, table, Id);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = false;
            }
            return ret_value;
        }

        public static XmlRpcStruct[] dsFindByField(string table, Int32 limit, Int32 page, string fieldName, string fieldValue, string[] selectedFields)
        {
            XmlRpcStruct[] retStructArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStructArray = api.dsFindByField(_ApiKey, table, limit, page, fieldName, fieldValue, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retStructArray = retFail;
            }
            return retStructArray;
        }

        public static XmlRpcStruct[] dsQuery(string table, Int32 limit, Int32 page, XmlRpcStruct queryData, string[] selectedFields)
        {
            XmlRpcStruct[] retStructArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStructArray = api.dsQuery(_ApiKey, table, limit, page, queryData, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retStructArray = retFail;
            }
            return retStructArray;
        }

        public static Int32 dsAddCustomField(string context, string displayName, string dataType, Int32 groupId)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAddCustomField(_ApiKey, context, displayName, dataType, groupId);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static Int32 dsAuthenticateUser(string username, string passwordHash)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAuthenticateUser(_ApiKey, username, passwordHash);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static string dsGetAppSetting(string module, string setting)
        {
            string ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsGetAppSetting(_ApiKey, module, setting);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = string.Empty;
            }
            return ret_value;
        }

        public static string dsGetTemporaryKey(string username, string passwordHash)
        {
            string ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsGetTemporaryKey(_ApiKey, username, passwordHash);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = string.Empty;
            }
            return ret_value;
        }

        public static Boolean dsUpdateCustomField(Int32 customFieldId, XmlRpcStruct values)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsUpdateCustomField(_ApiKey, customFieldId, values);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = false;
            }
            return ret_value;
        }

        #endregion

        #region APIEmailService
        /// <summary>
        /// Creates a new email template that can be used for future emails.
        /// mergeContext choices:Contact, ServiceCall, Opportunity and CreditCard
        /// contentType choices: html, text or multipart
        /// </summary>
        /// <param name="pieceTitle"></param>
        /// <param name="categories"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddress"></param>
        /// <param name="bccAddress"></param>
        /// <param name="subject"></param>
        /// <param name="textBody"></param>
        /// <param name="htmlBody"></param>
        /// <param name="contentType"></param>
        /// <param name="mergeContext"></param>
        /// <returns>Returns templateId of the created email template</returns>
        public static Int32 addEmailTemplate(string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esAddEmailTemplate(_ApiKey, pieceTitle, categories, fromAddress, toAddress, ccAddress, bccAddress, subject, textBody, htmlBody, contentType, mergeContext);
            }
            catch (Exception ex)
            {
                ret_value = -2;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContactId"></param>
        /// <param name="fromName"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="subject"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <param name="header"></param>
        /// <param name="receivedDate"></param>
        /// <param name="sentDate"></param>
        /// <param name="emailSentType"></param>
        /// <returns></returns>
        public static Boolean attachEmail(Int32 ContactId, String fromName, String fromAddress, String toAddress, String ccAddresses, String bccAddresses, String contentType, String subject, String htmlBody, String textBody, String header, String receivedDate, String sentDate, Int32 emailSentType)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esAttachEmail(_ApiKey, ContactId, fromName, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody, header, receivedDate, sentDate, emailSentType);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateTemplate"></param>
        /// <param name="userId"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="subject"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <returns></returns>
        public static Int32 createEmailTemplate(String templateTemplate, Int32 userId, String fromAddress, String toAddress, String ccAddresses, String bccAddresses, String contentType, String subject, String htmlBody, String textBody)
        {
            Int32 ret_value = 0;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esCreateEmailTemplate(_ApiKey, templateTemplate, userId, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mergeContext"></param>
        /// <returns></returns>
        public static String[] getAvailableMergeFields(string mergeContext)
        {
            string[] ret_value = { "Error" };
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetAvailableMergeFields(_ApiKey, mergeContext);
                // valid mergeContext values are html, text or multipart
            }
            catch (Exception ex)
            {
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static XmlRpcStruct getEmailTemplate(Int32 templateId)
        {
            XmlRpcStruct ret_value = new XmlRpcStruct();
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetEmailTemplate(_ApiKey, templateId);
            }
            catch (Exception ex)
            {
                ret_value = new XmlRpcStruct();
            }
            return ret_value;
        }

        /// <summary>
        /// getOptStatus indicates the status of a given customer found by email address
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <returns>Returns 0 if the customer is not opted in, 1 if they are single opted in, 2 if they are double opted in, </returns>
        public static Int32 getOptStatus(string email)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetOptStatus(_ApiKey, email);
            }
            catch (Exception ex)
            {
                ret_value = -2;
            }
            return ret_value;
        }

        /// <summary>
        /// OptIn contact
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <param name="permissionReason"></param>
        /// <returns>true if OptIn was successful, false if not. Will return false if already opted in</returns>
        public static Boolean optIn(string email, string permissionReason)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esOptIn(_ApiKey, email, permissionReason);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// OptOut contact
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <param name="permissionReason"></param>
        /// <returns>true if OptOut was successful, false if not. Will return false if already opted out</returns>
        public static Boolean optOut(string email, string revokeReason)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esOptOut(_ApiKey, email, revokeReason);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toADdress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <returns></returns>
        public static Boolean sendEmail(string[] contactList, string fromAddress, string toADdress, string ccAddresses, string bccAddresses, string contentType, string htmlBody, string textBody)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esSendEmail(_ApiKey, contactList, fromAddress, toADdress, ccAddresses, bccAddresses, contentType, htmlBody, textBody);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="pieceTitle"></param>
        /// <param name="categories"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddress"></param>
        /// <param name="bccAddress"></param>
        /// <param name="subject"></param>
        /// <param name="textBody"></param>
        /// <param name="htmlBody"></param>
        /// <param name="contentType"></param>
        /// <param name="mergeContext"></param>
        /// <returns></returns>
        public static Boolean updateEmailTemplate(int templateId, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esUpdateEmailTemplate(_ApiKey, templateId, pieceTitle, categories, fromAddress, toAddress, ccAddress, bccAddress, subject, textBody, htmlBody, contentType, mergeContext);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }
        #endregion

        #region APIAffiliateService
        #endregion

        #region InvoiceService
        #region core methods
        /// <summary>
        /// createBlankOrder will create a blank order for the given contactId. This empty order is then set to begin adding items into which would be the next step in the ecommerce transaction 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="description"></param>
        /// <param name="orderDate"></param>
        /// <param name="leadAffiliate"></param>
        /// <param name="saleAffiliate"></param>
        /// <returns>new order ID</returns>
        public static Int32 createBlankOrder(Int32 contactId, string description, DateTime orderDate, Int32 leadAffiliate, Int32 saleAffiliate)
        {
            Int32 newOrderNumber = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                newOrderNumber = api.isCreateBlankOrder(_ApiKey, contactId, description, orderDate, leadAffiliate, saleAffiliate);
            }
            catch (Exception ex)
            {
                newOrderNumber = -1;
            }

            return newOrderNumber;
        }

        /// <summary>
        /// addOrderItem adds a product to an existing order/invoice.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="productId"></param>
        /// <param name="type">one of [UNKNOWN = 0; SHIPPING = 1; TAX = 2; SERVICE = 3; PRODUCT = 4; UPSELL = 5; FINANCECHARGE = 6; SPECIAL = 7;]</param>
        /// <param name="Price"></param>
        /// <param name="quantity"></param>
        /// <param name="description">a short description of the title, typically you will want to use its name</param>
        /// <param name="notes">a long description of the title, typically you will want to use the product’s description field</param>
        /// <returns>true/false indicating success of the add attempt</returns>
        public static Boolean addOrderItem(Int32 invoiceId, Int32 productId, Int32 type, Double price, Int32 quantity, String description, String notes)
        {
            Boolean success = false;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                success = api.isAddOrderItem(_ApiKey, invoiceId, productId, type, price, quantity, description, notes);
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// chargeInvoice Charges a customer’s credit card for the outstanding amount on an existing invoice. You’ll need to have a creditCardId to use, which can be found with locateExistingCard() if your customer has purchased from you before, or from the DataService class if you need to insert a new credit card
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="notes"></param>
        /// <param name="creditCardId"></param>
        /// <param name="merchantAccountId"></param>
        /// <param name="bypassCommissions"></param>
        /// <returns>(struct) a struct containing payment details. The struct will contain the following keys:
        ///            * Successful – true or fale on whether or not the card was charged. (If there was nothing to charge, this will be false)
        ///            * Code – The approval code: APPROVED, DECLINED, ERROR, SKIPPED (there was no balance to charge)
        ///            * RefNum – If charge was successful, this is the reference number passed back by the merchant account
        ///            * Message – Error message for the transaction, if any
        /// </returns>
        public static XmlRpcStruct chargeInvoice(Int32 invoiceId, String notes, Int32 creditCardId, Int32 merchantAccountId, Boolean bypassCommissions)
        {
            XmlRpcStruct paymentDetails = new XmlRpcStruct();

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                paymentDetails = api.isChargeInvoice(_ApiKey, invoiceId, notes, creditCardId, merchantAccountId, bypassCommissions);
            }
            catch (Exception ex)
            {
                //paymentDetails = ;
            }

            return paymentDetails;
        }

        // public static Boolean deleteInvoice()
        // public static Boolean deleteSubscription()
        #endregion

        #region Subscription methods
        public static Int32 addRecurringOrder(Int32 contactId, Boolean allowDuplicate, Int32 cProgramId, Int32 qty, Double price, Boolean allowTax, Int32 merchantAccountId, Int32 creditCardId, Int32 affiliateId, Int32 daysTillCharge)
        {
            Int32 ret_value = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isAddRecurringOrder(_ApiKey, contactId, allowDuplicate, cProgramId, qty, price, allowTax, merchantAccountId, creditCardId, affiliateId, daysTillCharge);
            }
            catch (Exception)
            {
                ret_value = 0;
            }

            return ret_value;
        }

        // public static Int32 addRecurringCommissionOverride()

        public static Int32 createInvoiceForRecurring(Int32 recurringOrderId)
        {
            Int32 ret_value = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isCreateInvoiceForRecurring(_ApiKey, recurringOrderId);
            }
            catch (Exception)
            {
                ret_value = 0;
            }

            return ret_value;
        }

        // public static Boolean updateJobRecurringNextBillDate()
        #endregion

        #region Payment methods
        // public static Boolean addManualPayment()
        // public static Boolean addPaymentPlan()
        // public static Double calculateAmountOwed()

        /// <summary>
        /// getAllPaymentOptions is used to retrieve all Payment Types currently setup under the Order Settings section of Infusionsoft
        /// </summary>
        /// <returns>(struct) all valid payment types currently setup in the application. Returns a single structure containing key called ErrorMessage with the value containing the message of the error.</returns>
        public static XmlRpcStruct[] getAllPaymentOptions()
        {
            XmlRpcStruct[] ret_value;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isGetAllPaymentOptions(_ApiKey);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = new XmlRpcStruct[1] { fail };
            }
            return ret_value;
        }
        // Returns all valid payment types as set up in the CRM
        // Array
        // (
        //     [Credit Card] => Credit Card
        //     [Check] => Check
        //     [Cash] => Cash
        //     [Money Order] => Money Order
        //     [Adjustment] => Adjustment
        //     [Credit] => Credit
        //     [Refund] => Refund
        // )

        // public static array getPayments()

        /// <summary>
        /// locateExistingCard finds a credit card on file for a contactId that matches the last four digits of the card. Make sure to send only the last four digits of the credit card.
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="last4"></param>
        /// <returns>(int) creditCardId if the card is found. Zero if no card matches</returns>
        public static Int32 locateExistingCard(int contactId, string last4)
        {
            Int32 cardId = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                cardId = api.isLocateExistingCard(_ApiKey, contactId, last4);
            }
            catch (Exception)
            {
                cardId = 0;
            }

            return cardId;
        }

        // public static Boolean recalculateTax()
        // public static XmlRpcStruct validateCreditCard()
        #endregion

        #region Misc methods
        /// <summary>
        /// getAllShippingOptions() creates a string array of all the available shipping options for this InfusionSoft Application
        /// </summary>
        /// <returns>Returns a string array of all the available shipping</returns>
        public static String[] getAllShippingOptions()
        {
            String[] AllShippingOptions = { };

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                AllShippingOptions = api.isGetAllShippingOptions(_ApiKey);
            }
            catch (Exception ex)
            {
                //
            }

            return AllShippingOptions;
        }

        /// <summary>
        /// getPluginStatus retrieves the current status of the given plugin
        /// </summary>
        /// <param name="fullyQualifiedClassName"></param>
        /// <returns>(string) the current status of the plugin</returns>
        public static String getPluginStatus(string fullyQualifiedClassName)
        {
            String ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isGetPluginStatus(_ApiKey, fullyQualifiedClassName);
            }
            catch (Exception ex)
            {
                ret_value = string.Empty;
            }
            return ret_value;
        }
        #endregion

        #endregion

    }
}