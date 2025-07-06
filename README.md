![PlatformPlatform Resource Groups](https://platformplatformgithub.blob.core.windows.net/$root/GitHubTopBanner.png)

# 👋 Welcome to PlatformPlatform

PlatformPlatform is a free, opinionated foundation for any modern SaaS solution based on .NET as the backend and React as the frontend. It provides you with ready-made fundamental building blocks like Infrastructure as Code and CI/CD pipelines, so you and your team can focus on what matters most: your app!

## Why do I need PlatformPlatform?

When a new SaaS solution is in its early stages, there's a lot to handle:

- Finding Product-Market Fit  
- Pitching to investors  
- Market research  
- Go-to-market strategy

...and then, of course, there's building the product itself. As we all know, eventually it needs to be:

- Maintainable  
- Secure  
- Easy to deploy

...and so on. But with all the activity in this phase, it's normal to cut corners due to a lack of time or incentive—especially when it’s still uncertain whether the product will succeed. And when it does succeed 🤞, it often comes with a lot of technical debt that must be resolved before scaling.

**💡 PlatformPlatform enables you to do it right from day one on the technical side, with no extra overhead.**  
You get all the best practices we’ve gathered over the years building top-tier B2B & B2C cloud SaaS products—with sleek design, full localization and accessibility, vertical slice architecture, fast automated DevOps, and top-notch security.

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=PlatformPlatform_platformplatform&metric=alert_status)](https://sonarcloud.io/summary/overall?id=PlatformPlatform_platformplatform) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=PlatformPlatform_platformplatform&metric=security_rating)](https://sonarcloud.io/component_measures?id=PlatformPlatform_platformplatform&metric=Security) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=PlatformPlatform_platformplatform&metric=reliability_rating)](https://sonarcloud.io/component_measures?id=PlatformPlatform_platformplatform&metric=Reliability) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=PlatformPlatform_platformplatform&metric=sqale_rating)](https://sonarcloud.io/component_measures?id=PlatformPlatform_platformplatform&metric=Maintainability)

> [!Caution]  
> This project is still in alpha. Follow our [up-to-date roadmap](https://github.com/orgs/PlatformPlatform/projects/2/views/2) for further details.

### What’s included?

- **Backend** – .NET 9 and C# following the principles of vertical slice architecture, DDD, CQRS, and clean code  
- **Frontend** – React 19 and TypeScript, fully localized using React Aria components for world-class accessibility  
- **CI/CD** – GitHub Actions for fast, passwordless deployments of application (Docker) and infrastructure (Bicep)  
- **Infrastructure** – Cost-efficient, scalable Azure PaaS services like Azure Container Apps, Azure SQL, and more  
- **Developer CLI** – Extensible .NET CLI for DevEx—set up CI/CD with a single command and a few prompts  

---

## How does it work in practice?

1. Fork this GitHub repository as a foundation for your solution  
2. Build your product on top of the best-practice foundation (or replace parts if needed)  
3. Pull in later innovations from us as you see fit

## Next Steps

As the project is still in its early days, we recommend you [contact us](mailto:tje@platformplatform.net) for a curated introduction.

**--- or ---**

Try the foundation yourself by following the Getting Started guide below

> Note: The getting started experience focuses on the backend fundamentals of a SaaS platform and not on the final visuals (because you should change/tweaks those at the end to make the platform truly your own). This means that you will "only" see a sample landing page and a basic mangement portal interface to manage users while you run the demo.

### Getting Started 1-2-3

TL;DR: Open the [PlatformPlatform](/application/PlatformPlatform.slnx) solution in Rider or Visual Studio and run the [Aspire AppHost](/application/AppHost/AppHost.csproj) project.

<img src="https://platformplatformgithub.blob.core.windows.net/$root/local-developer-experience.gif" alt="Getting Started" title="Developer Experience" width="800"/>

### Prerequisites

You'll need .NET, Docker, and Node for development. GitHub and Azure CLI are required for CI/CD setup.

<details>
<summary>Install prerequisites for Windows</summary>

1. Open a PowerShell terminal as Administrator and run:
   ```
   wsl --install
   ```
2. Restart your computer if prompted.  
3. Run the following to install dependencies:
   ```powershell
   @(
       "Microsoft.DotNet.SDK.9",
       "Git.Git",
       "Docker.DockerDesktop",
       "OpenJS.NodeJS",
       "Microsoft.AzureCLI",
       "GitHub.cli"
   ) | ForEach-Object { winget install --accept-package-agreements --accept-source-agreements --id $_ }
   ```
</details>

<details>
<summary>Install prerequisites for Mac</summary>

```bash
brew install --cask dotnet-sdk
brew install --cask docker
brew install git node azure-cli gh
```
</details>

<details>
<summary>Install prerequisites for Linux/WSL2</summary>

See original instructions (no changes needed) – they are correct and detailed.
</details>

</details>

## 1. Clone the Repository

Forking is only required if you want to set up CI/CD from your own GitHub repo to Azure ([step 3](#3-set-up-cicd-with-passwordless-deployments-from-github-to-azure)).

We recommend preserving our clean commit history—it’s great for learning and troubleshooting 😃

## 2. Run Aspire AppHost to Spin Up Everything Locally

Using .NET Aspire, Docker images for SQL Server, Blob Storage, and Mail Server are pulled and started. No manual setup required.

```bash
cd application/AppHost
dotnet run # First run may be slow due to Docker image downloads
```

Alternatively, open the [PlatformPlatform](/application/PlatformPlatform.slnx) solution and run the [Aspire AppHost](/application/AppHost/AppHost.csproj) project.

## 3. Set Up CI/CD with Passwordless Deployments from GitHub to Azure [Optional]

Run this command to configure your Azure subscription and GitHub Actions workflows:

```bash
cd developer-cli
dotnet run configure-continuous-deployments # Add --verbose-logging for CLI details
```

You must be the owner of the GitHub repository and Azure subscription, with rights to create Service Principals and AD groups.

The tool will guide you through login and setup, then show a list of planned changes before applying them.

![Configure Continuous Deployments](https://platformplatformgithub.blob.core.windows.net/$root/ConfigureContinuousDeployments.png)

Everything except adding a DNS record is fully automated. At the end, you’ll get guidance on branch policies, SonarCloud, and more.

The infrastructure is cost-optimized and auto-scaling. It costs less than $2/day and can scale to millions of users 🎉
