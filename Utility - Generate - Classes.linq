<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.FileSystem.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Queryable.dll</Reference>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	try{
		string createdBy = "TS MOGANO";
		string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
		string directoryCurrent = System.IO.Directory.GetCurrentDirectory();
		string directoryRoot = System.IO.Directory.GetParent(directoryCurrent).ToString();
		
		directoryCurrent.Dump();
		directoryRoot.Dump();
		
		
		
		string dirSource = @"C:\Users\A236978\source\repos\console-app-working-with-sorting-algorigthms";
		string [] dirSourceFiles = System.IO.Directory.EnumerateFiles(dirSource, "*.cs", SearchOption.TopDirectoryOnly).ToArray();
		string dirTarget = @"\\10.147.36.254\d$\Temp\Testing\JSEDownload";
		string [] dirTargetFiles = System.IO.Directory.EnumerateFiles(dirTarget, "*.*", SearchOption.TopDirectoryOnly).ToArray();

		dirTargetFiles.Select((file) => (new FileInfo(file)).Name).Dump();

	}catch(Exception exception){
		exception.Dump();
	}finally{}
}

// Define other methods and classes here
public string SplitCamelCase(string str)
{
	return Regex.Replace( Regex.Replace( str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2" ), @"(\p{Ll})(\P{Ll})", "$1 $2" );
}
private void cleanAndDeleteDirectory(string path){
	if(System.IO.Directory.Exists(path)){
		Console.WriteLine("Clean and Delete Directory : {0}", path);
		System.IO.DirectoryInfo rootDir = new DirectoryInfo(path);
		foreach (FileInfo file in rootDir.EnumerateFiles())
		{
		    file.Delete(); 
		}
		foreach (DirectoryInfo dir in rootDir.EnumerateDirectories())
		{
		    cleanAndDeleteDirectory(dir.ToString());
		}
		rootDir.Delete(true);
	}
}
private void createDirectoryIfNotExists(string path){
	if(!System.IO.Directory.Exists(path)){
		Console.WriteLine("Create Directory : {0}", path);
		System.IO.Directory.CreateDirectory(path);
	}
}
private void deleteFileIfExists(string path){
	if(System.IO.File.Exists(path)){
		Console.WriteLine("Delete File : {0}", path);
		System.IO.File.Delete(path);
	}
}
private void createFileIfNotExists(string path, string content){
	if(!System.IO.File.Exists(path)){
		Console.WriteLine("Create File : {0}", path);
		System.IO.File.WriteAllText(path, content);
	}
}
private void replaceFile(string path, string content){
	deleteFileIfExists(path);
	System.IO.File.WriteAllText(path, content);
}
private String templateMsSqlModelIdasGenioDbApi(string createdBy, string dateCreated, string schemaName, string tableName, string entityParameters, string componentParameters, string componentReturnParameters) {
	System.Text.StringBuilder sb = new StringBuilder();
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Author:		" + createdBy);
	sb.AppendLine("| Create date:	" + dateCreated);
	sb.AppendLine("| Description:	IDAS - Genio - API - MS SQL Entity (Model) utility class for the [" + schemaName + "].[" + tableName + "] Table");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Function(s)");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("const " + tableName + " = () => {");
	sb.AppendLine("	const fromEntity = (entity = {}) => {");
	sb.AppendLine("		return fromComponents(" + entityParameters + ");");
	sb.AppendLine("	}");
	sb.AppendLine("	const fromComponents = (" + componentParameters + ") => {");
	sb.AppendLine("		return {");
	sb.AppendLine(String.Format("\t\t\t{0}", componentReturnParameters));
	sb.AppendLine("		}");
	sb.AppendLine("	}");
	sb.AppendLine("	return {");
	sb.AppendLine("		fromEntity: fromEntity,");
	sb.AppendLine("		fromComponents: fromComponents");
	sb.AppendLine("	}");
	sb.AppendLine("}");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| module.exports");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("module.exports = " + tableName + ";");
	return sb.ToString();
}
private String templateMsSqlRepositoryIdasGenioDbApi(string createdBy, string dateCreated, string schemaName, string tableName){
	System.Text.StringBuilder sb = new StringBuilder();
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Author:		" + createdBy);
	sb.AppendLine("| Create date:	" + dateCreated);
	sb.AppendLine("| Description:	IDAS - Genio - API - MS SQL Entity (Model) Repository utility class for the [" + schemaName + "].[" + tableName + "] Table");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Dependency(ies)");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("const entityName = `" + tableName + "`;");
	sb.AppendLine("const _" + tableName + " = require(`./../../models/mssql/" + tableName + "`);");
	sb.AppendLine("const _dbContext = require(`./../../db-context/mssql/mssql-idas-genio-db-context`);");
	sb.AppendLine("const { onHttpRequestCompleted } = require(`../../../common/logging/logger`);");
	sb.AppendLine("const { getRequestQueryParametersWithoutUid } = require(`../../../common/http-helper`);");
	if(tableName.Equals("FileAttachment")){
		sb.AppendLine("const { writeFileAttachmentToDisc } = require(`../../../common/functions`);");
	}
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Function(s)");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("const Repository = () => {");
	sb.AppendLine("    const " + tableName + " = _" + tableName + "();");
	sb.AppendLine("    const dbContext = _dbContext();");
	sb.AppendLine("    const create = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	//sb.AppendLine("            const entity = " + tableName + ".fromEntity(request.body);");
	sb.AppendLine("            dbContext.create(uid, entityName, request.body, (error, data, message) => {");
	if(tableName.Equals("FileAttachment")){
		sb.AppendLine("                writeFileAttachmentToDisc(error, data[0]);");
	}
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    const getAll = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	sb.AppendLine("            dbContext.getAll(uid, entityName, (error, data, message) => {");
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    const getById = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	sb.AppendLine("            const entityId = request.query.id;");
	sb.AppendLine("            dbContext.getById(uid, entityName, entityId, (error, data, message) => {");
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    const getBy = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	sb.AppendLine("            dbContext.getBy(uid, entityName, getRequestQueryParametersWithoutUid(request), (error, data, message) => {");
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    const update = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	// sb.AppendLine("            const entity = " + tableName + ".fromEntity(request.body);");
	sb.AppendLine("            dbContext.update(uid, entityName, request.body, (error, data, message) => {");
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    const _delete = (request, response, next) => {");
	sb.AppendLine("        try{");
	sb.AppendLine("            const uid = request.query.uid;");
	// sb.AppendLine("            const entity = " + tableName + ".fromEntity(request.body);");
	sb.AppendLine("            dbContext.delete(uid, entityName, request.body._id, (error, data, message) => {");
	sb.AppendLine("                return onHttpRequestCompleted(__filename, request, response, error, data, message);");
	sb.AppendLine("            });");
	sb.AppendLine("        }catch(error){");
	sb.AppendLine("            return onHttpRequestCompleted(__filename, request, response, error);");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	if(tableName.Equals("User")){
		sb.AppendLine("  const callGetUserProfile = (");
		sb.AppendLine("    uid,");
		sb.AppendLine("    emailAddress,");
		sb.AppendLine("    id = null,");
		sb.AppendLine("    employeeId = null,");
		sb.AppendLine("    clientId = null,");
		sb.AppendLine("    supplierId = null,");
		sb.AppendLine("    callback");
		sb.AppendLine("  ) => {");
		sb.AppendLine("    try {");
		sb.AppendLine("      dbContext.executeScalarFunction(");
		sb.AppendLine("        `dbo`,");
		sb.AppendLine("        \"GetUserProfile\",");
		sb.AppendLine("        [");
		sb.AppendLine("          { EmailAddress: emailAddress },");
		sb.AppendLine("          { _id: id },");
		sb.AppendLine("          { EmployeeId: employeeId },");
		sb.AppendLine("          { ClientId: clientId },");
		sb.AppendLine("          { SupplierId: supplierId },");
		sb.AppendLine("        ],");
		sb.AppendLine("        false,");
		sb.AppendLine("        callback");
		sb.AppendLine("      );");
		sb.AppendLine("    } catch (error) {");
		sb.AppendLine("      callback(error);");
		sb.AppendLine("    } finally {");
		sb.AppendLine("    }");
		sb.AppendLine("  };");
		sb.AppendLine("  const callOnSuccessfulLoginOrLogout = (entity, callback) => {");
		sb.AppendLine("    try {");
		sb.AppendLine("      dbContext.executeStoredProcedure(");
		sb.AppendLine("        `dbo`,");
		sb.AppendLine("        \"spAuthentication_OnSuccessfulLoginOrLogout\",");
		sb.AppendLine("        {");
		sb.AppendLine("          _id: entity._id,");
		sb.AppendLine("          DateLastLoggedIn: entity.DateLastLoggedIn,");
		sb.AppendLine("          SessionToken: entity.SessionToken,");
		sb.AppendLine("          ModifiedBy: entity.ModifiedBy || entity._id");
		sb.AppendLine("        },");
		sb.AppendLine("        false,");
		sb.AppendLine("        callback");
		sb.AppendLine("      );");
		sb.AppendLine("    } catch (error) {");
		sb.AppendLine("      callback(error);");
		sb.AppendLine("    } finally {");
		sb.AppendLine("    }");
		sb.AppendLine("  };");
	}
	sb.AppendLine("    return {");
	sb.AppendLine("        create: create,");
	sb.AppendLine("        getAll: getAll,");
	sb.AppendLine("        getById: getById,");
	sb.AppendLine("        getBy: getBy,");
	sb.AppendLine("        update: update,");
	sb.AppendLine("        delete: _delete,");
	if(tableName.Equals("User")){
		sb.AppendLine("        callGetUserProfile: callGetUserProfile,");
		sb.AppendLine("        onSuccessfulLogin: callOnSuccessfulLoginOrLogout,");
		sb.AppendLine("        onSuccessfulLogout: callOnSuccessfulLoginOrLogout,");
	}
	sb.AppendLine("    }");
	sb.AppendLine("}");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| module.exports");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("module.exports = Repository;");
	return sb.ToString();
}
private String templateMsSqlModelIdasGenioDbApiDefaultUserProfile(string createdBy, string dateCreated) {
	System.Text.StringBuilder sb = new StringBuilder();
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Author:		" + createdBy);
	sb.AppendLine("| Create date:	" + dateCreated);
	sb.AppendLine("| Description:	IDAS - Genio - API - Entity (Model) for the UserProfile");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| Function(s)");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("const UserProfile = () => {");
	sb.AppendLine("    const fromComponents = (user = {}, employee = {}, client = {}, supplier = {}, contactDetail = {}) => {");
	sb.AppendLine("        user.EmployeeId = employee._id;");
	sb.AppendLine("        user.ClientId = client._id;");
	sb.AppendLine("        user.SupplierId = supplier._id;");
	sb.AppendLine("        return {");
	sb.AppendLine("            User : user,");
	sb.AppendLine("            Employee : employee,");
	sb.AppendLine("            Client : client,");
	sb.AppendLine("            Supplier : supplier,");
	sb.AppendLine("            ContactDetail : contactDetail,");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("    return {");
	sb.AppendLine("        fromComponents: fromComponents");
	sb.AppendLine("    }");
	sb.AppendLine("}");
	sb.AppendLine("");
	sb.AppendLine("/*");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine("| module.exports");
	sb.AppendLine("|--------------------------------------------------------------------------------------------------------------------------------------------");
	sb.AppendLine(" */");
	sb.AppendLine("module.exports = UserProfile;");
	return sb.ToString();
}