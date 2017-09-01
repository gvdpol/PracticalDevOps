param 
(    
   $tool = "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe",    
   $paths,    
   $include = "*.webtest",    
   $results ,    
   $testsettings
)

$web_tests = get-ChildItem -Path $paths -Recurse -Include $include

foreach ($item in $web_tests) {    
   $args += "/TestContainer:$item "
}

& $tool $args /resultsfile:$Results /testsettings:$testsettings
