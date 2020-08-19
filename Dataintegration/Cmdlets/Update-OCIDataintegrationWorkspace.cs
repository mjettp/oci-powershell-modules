/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200430
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DataintegrationService.Requests;
using Oci.DataintegrationService.Responses;
using Oci.DataintegrationService.Models;

namespace Oci.DataintegrationService.Cmdlets
{
    [Cmdlet("Update", "OCIDataintegrationWorkspace")]
    [OutputType(new System.Type[] { typeof(Oci.DataintegrationService.Models.Workspace), typeof(Oci.DataintegrationService.Responses.UpdateWorkspaceResponse) })]
    public class UpdateOCIDataintegrationWorkspace : OCIDataIntegrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"DIS workspace id")]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateWorkspaceDetails UpdateWorkspaceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Update and Delete operations should accept an optional If-Match header, in which clients can send a previously-received ETag. When If-Match is provided and its value does not exactly match the ETag of the resource on the server, the request should fail with HTTP response status code 412")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateWorkspaceRequest request;

            try
            {
                request = new UpdateWorkspaceRequest
                {
                    WorkspaceId = WorkspaceId,
                    UpdateWorkspaceDetails = UpdateWorkspaceDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateWorkspace(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Workspace);
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

        private UpdateWorkspaceResponse response;
    }
}
