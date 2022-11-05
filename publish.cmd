@echo off
echo "Restoring tools..."
dotnet tool restore
echo "Start building..."
dotnet cake build/build.cake --target=Publish
echo "Complete!"