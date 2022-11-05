echo "Restoring tools..."
dotnet tool restore
echo "Start building..."
dotnet cake build/build.cake --target=Publish --runtime=linux-x64
echo "Complete!"