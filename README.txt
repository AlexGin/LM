License Manager - Accounting System issued license keys.
_______________________________________________________

Platform: MS SQL Server, C#

I. Functions
1. Keeping accounting issued license keys and license keys for test organizations.
2. Operational search by various parameters key fields.
3. Viewing the "history" on the key: whether the extension of the key, for what period has been extended, 
   the extension of the reason.
4. View the number of the license and license key test in enterprises in the list.
5. View the complete list of issued keys to display information about the company, 
   about the owner of a key feature of the significance of test key.

II. Requirements
1. An organization can not obtain license keys above the specified limit. The limit is set for each organization separately
2. An organization may obtain an unlimited number of test license keys
3. Date of issue key may not match the date of commencement of the key steps
4. License key validity period may be extended (requires fixing the causes of prolongation). Extending the procedure 
   followed by the transfer of key importance.
5. The key is tied to a specific device
6. Log in to the system. Provide an option when the username and password of end users have already been created in the database.
7. (optional, but encouraged) a distinction on access rights

III. Essence
3.1. Organization
The minimal set of fields:
Name of organization - Text field (256)
Document number - Text field (128)
Limit Of keys - Int
Comment:
Keys limit does not apply to test keys.
To provide the ability to display by key statistics:
1) Number of issued keys and limit value;
2) The number of active test keys

3.2 Device
The minimal set of fields:
Code of key - Text field (32) - Receive customer. It may change during operation.
Name of owner - Text field (128)
Position of owner - Text field (128)
Devices attached to the Organization.
To provide for the preservation of the history of changes in the key. If you change the device code is transferred to the customer a new key value.
To provide the ability to view information about the organization, which is tied to the device.
To provide the ability to view key information, which is issued for this device.

3.3 Key
The minimal set of fields:
Value of key - Text field (64)
Start Date (datetime) - Date of commencement of the license period
End Date (datetime) - The end date of the license period
Flag of test (smallint)
Comments:
To provide the ability to view information about the key code of the device.
To implement this requirement, the essence of the "key" must be able to have a few "key value" values ​​with expiration dates.
Example:
The key key1 is tied to the organization and the device and has a value of Value1.
Let's say the key is not a test. For some reason, we have decided to extend the validity of this key. 
Generated (third-party application) a new value (Value2) key1 key. 
Accounting program should "remember" Value1 and attributes (test start date and end date) and Value2 and display attributes corresponding value.
When browsing history to display attributes and Value1, Value2 and attributes.