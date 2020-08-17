/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;
using Oci.ObjectstorageService.Models;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("Remove", "OCIObjectstoragePreauthenticatedRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.ObjectstorageService.Responses.DeletePreauthenticatedRequestResponse) })]
    public class RemoveOCIObjectstoragePreauthenticatedRequest : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier for the pre-authenticated request. This can be used to manage operations against the pre-authenticated request, such as GET or DELETE.")]
        public string ParId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIObjectstoragePreauthenticatedRequest", "Remove"))
            {
               return;
            }

            DeletePreauthenticatedRequestRequest request;

            try
            {
                request = new DeletePreauthenticatedRequestRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    ParId = ParId,
                    OpcClientRequestId = OpcClientRequestId
                };

                response = client.DeletePreauthenticatedRequest(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private DeletePreauthenticatedRequestResponse response;
    }
}
