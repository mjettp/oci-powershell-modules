/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OnsService.Requests;
using Oci.OnsService.Responses;
using Oci.OnsService.Models;

namespace Oci.OnsService.Cmdlets
{
    [Cmdlet("Invoke", "OCIOnsResendSubscriptionConfirmation")]
    [OutputType(new System.Type[] { typeof(Oci.OnsService.Models.Subscription), typeof(Oci.OnsService.Responses.ResendSubscriptionConfirmationResponse) })]
    public class InvokeOCIOnsResendSubscriptionConfirmation : OCINotificationDataPlaneCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the subscription to resend the confirmation for.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ResendSubscriptionConfirmationRequest request;

            try
            {
                request = new ResendSubscriptionConfirmationRequest
                {
                    Id = Id,
                    OpcRequestId = OpcRequestId
                };

                response = client.ResendSubscriptionConfirmation(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Subscription);
                FinishProcessing(response);
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            TerminatingErrorDuringExecution(new OperationCanceledException("Cmdlet execution interrupted"));
        }

        private ResendSubscriptionConfirmationResponse response;
    }
}
