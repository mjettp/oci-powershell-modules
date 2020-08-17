/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.IdentityService.Requests;
using Oci.IdentityService.Responses;
using Oci.IdentityService.Models;

namespace Oci.IdentityService.Cmdlets
{
    [Cmdlet("Move", "OCIIdentityTagNamespaceCompartment")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.IdentityService.Responses.ChangeTagNamespaceCompartmentResponse) })]
    public class MoveOCIIdentityTagNamespaceCompartment : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the tag namespace.")]
        public string TagNamespaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for changing the compartment of a tag namespace.")]
        public ChangeTagNamespaceCompartmentDetail ChangeTagNamespaceCompartmentDetail { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ChangeTagNamespaceCompartmentRequest request;

            try
            {
                request = new ChangeTagNamespaceCompartmentRequest
                {
                    TagNamespaceId = TagNamespaceId,
                    ChangeTagNamespaceCompartmentDetail = ChangeTagNamespaceCompartmentDetail,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.ChangeTagNamespaceCompartment(request).GetAwaiter().GetResult();
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

        private ChangeTagNamespaceCompartmentResponse response;
    }
}
