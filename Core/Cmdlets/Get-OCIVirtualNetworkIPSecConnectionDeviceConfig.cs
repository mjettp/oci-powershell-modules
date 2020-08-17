/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Get", "OCIVirtualNetworkIPSecConnectionDeviceConfig")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.IPSecConnectionDeviceConfig), typeof(Oci.CoreService.Responses.GetIPSecConnectionDeviceConfigResponse) })]
    public class GetOCIVirtualNetworkIPSecConnectionDeviceConfig : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the IPSec connection.")]
        public string IpscId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetIPSecConnectionDeviceConfigRequest request;

            try
            {
                request = new GetIPSecConnectionDeviceConfigRequest
                {
                    IpscId = IpscId
                };

                response = client.GetIPSecConnectionDeviceConfig(request).GetAwaiter().GetResult();
                WriteOutput(response, response.IPSecConnectionDeviceConfig);
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

        private GetIPSecConnectionDeviceConfigResponse response;
    }
}
