Partial Class QBDataSet

    '   SELECT        CustomerService.CustomerServiceID, CustomerService.CustomerNumber, CustomerService.ServiceTypeID, CustomerService.CustomerServiceRate, 
    '                         CustomerService.CustomerServiceQuantity, CustomerService.CustomerLastBatchInvoiceDate, CustomerService.CustomerInvoiceSchedule, 
    '                         Customer.CustomerInvoiceDOM, Customer.CustomerLastInvoiceDate
    'FROM            CustomerService RIGHT OUTER JOIN
    '                         Customer ON CustomerService.CustomerNumber = Customer.CustomerNumber
    'WHERE        (Customer.CustomerInvoiceDOM = DAY(GETDATE())) AND (DATEADD(month, CustomerService.CustomerInvoiceSchedule, 
    '                         CustomerService.CustomerLastBatchInvoiceDate) <= GETDATE()) AND (CustomerService.CustomerLastBatchInvoiceDate IS NOT NULL)

    Partial Class LineItemListDataTable

    End Class

    Partial Class LineItemDataTable

    End Class

    Partial Class CustomerListDataTable

    End Class

    Partial Class CustomerDataTable

    End Class

End Class




