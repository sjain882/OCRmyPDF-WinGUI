<h1 align="left">
  <img src="./Icon.ico" alt="OCRmyPDF - Simple Windows Frontend" width="35" align="top">
  <b>OCRmyPDF - Simple Windows Frontend</b>
  <br>
</h1>

<div align="center">

<img style="width: 75%; height: 75%" src="https://github.com/sjain882/OCRmyPDF-WinGUI/blob/main/.github/Previews/MainWindow/Preview.gif?raw=true"/>

<br>
<br>

<p align="center"> <b>
  <a href="https://github.com/sjain882/OCRmyPDF-WinGUI/releases/latest">📦 Download Now</a> •
  <a href="https://github.com/sjain882/OCRmyPDF-WinGUI/issues">🐛 Found a Bug?</a> •
  <a href="https://github.com/sjain882/OCRmyPDF-WinGUI/issues">💡 Share Ideas</a> •
  <a href="https://github.com/sjain882/OCRmyPDF-WinGUI/pulls">📈 Contribute</a>
</b></p>

[![ISSUES](https://img.shields.io/github/issues/sjain882/OCRmyPDF-WinGUI?color=F57C00&style=flat)](https://github.com/sjain882/OCRmyPDF-WinGUI/issues)
[![VERSION](https://img.shields.io/github/v/release/sjain882/OCRmyPDF-WinGUI?color=26A69A&style=flat&label=version)](https://github.com/sjain882/OCRmyPDF-WinGUI/releases/latest)
[![DOWNLOAD](https://img.shields.io/github/downloads/sjain882/OCRmyPDF-WinGUI/total?label=downloads&color=2E7D32)](https://github.com/sjain882/OCRmyPDF-WinGUI/releases/download/v0.1.0/OCRmyPDF-WinGUI.v0.1.0.zip)
[![DOTNET8](https://img.shields.io/badge/.NET%20-%208.0-512bd4)](https://dotnet.microsoft.com/en-us/download)

Responsive .NET 8 GUI for **[OCRmyPDF](https://github.com/ocrmypdf/OCRmyPDF)**, adhering to WPF MVVM principles.

Designed for novice users.
<br>
</div>

‎
‎
<details>
<summary>🖼 Additional previews</summary>
‎
‎

Static previews are available in each subfolder **[here](https://github.com/sjain882/OCRmyPDF-WinGUI/tree/main/.github/Previews)**

<img src="https://github.com/sjain882/OCRmyPDF-WinGUI/blob/main/.github/Previews/ErrorListWindow/Preview.gif?raw=true" width="55%" height="55%"/>
</details>

## 🖥 Supported operating systems

- Supported on **Windows 10 1607+**
- Tested on **Windows 10 22H2**
- May work on previous OS versions, but this is **[unsupported](https://github.com/dotnet/core/blob/main/release-notes/8.0/supported-os.md)**.
- OCRmyPDF is only available on **64-bit** operating systems.

‎
‎
## ❗ Pre-installation

> [!IMPORTANT]
> This program assumes OCRmyPDF is installed and present in the system PATH.<br>
> You can achieve this by following the official "Native Windows" [instructions](https://ocrmypdf.readthedocs.io/en/latest/installation.html#installing-on-windows).<br>
> I encountered multiple hindrances, however. Here are the exact steps I followed: 

<details> 
<summary>📜 Instructions</summary> 

1. Start an Administrator Command Prompt / PowerShell window.

2. [Install](https://chocolatey.org/install) or [update](https://community.chocolatey.org/courses/installation/upgrading) the Chocolatey package manager if you haven't done so already.

3. Run the following commands and follow the on-screen instructions, making sure to select "Yes to all" when prompted:

4. Install (`choco install python3`) or update (`choco upgrade python3`) Python 3.

5. Restart your Command Prompt / PowerShell window and verify Python was added to your PATH with `python -V`. If not, solve the issue (there are multiple potential causes which will not be detailed here).

5. Upgrade PIP: `python -m pip install --upgrade pip`.

6. Install GhostScript: `choco install ghostscript`.

7. Install Tesseract: `choco install --pre tesseract`.

8. Install PNGQuant (optional but recommended): `choco install pngquant`.

9. Install jbig2 (optional but recommended). First, download it from [SourceForge](https://sourceforge.net/projects/jbig2enc/files/latest/download).

10. Extract the contents of the folder inside the .zip archive to `C:\Program Files\jbig2enc`.

11. Add the folder to your PATH environment variables: `setx /M PATH "%PATH%;C:\Program Files\jbig2enc"`

12. Install OCRmyPDF:  `python -m pip install ocrmypdf`

13. If you recieve PATH warnings, add the **displayed** Python Scripts folder to your PATH environment variables, **e.g:** `setx /M PATH "%PATH%;C:\Python312\Scripts"`
</details>

‎
‎
## 🔐 Digital Signing of Release Binaries

All `*.exe` binary files of this project compiled by me are digitally self-signed. The attached certificate should carry this serial number:

`18f6cc78c0fa778b4545c6d9d135cb52`

If the serial number on your copy does not match this, or the digital certificate is missing the file has potentially been tampered with and should be deleted immediately.

You can check this by right clicking on the `OCRmyPDF-WinGUI` .exe / Application file > Properties > Digital Signatures > Select the one named "sjain882" > Details > View Certificate > Details > Serial Number.

‎
‎
## 💖 Thanks to

- The **[OCRmyPDF](https://github.com/ocrmypdf/OCRmyPDF)** project for the CLI program used by this tool

- The **[SvgToXaml](https://github.com/BerndK/SvgToXaml)** project for allowing conversion of SVG images to XAML resource dictionaries

- **[SVGRepo](https://www.svgrepo.com/)** for providing the application icon

- **[AngryCarrot789](https://github.com/AngryCarrot789)** for creating **[WPFDarkTheme](https://github.com/AngryCarrot789/WPFDarkTheme)** - simple & easy to use dark theme that respects default WPF controls

- **[DerekGooding](https://github.com/DerekGooding)** for **[updating](https://github.com/AngryCarrot789/WPFDarkTheme/pull/32)** **[WPFDarkTheme](https://github.com/DerekGooding/WPFDarkTheme)** to .NET 8

- **[Kampa Plays](https://www.youtube.com/@KampaPlays)** for a great set of **[C# WPF tutorials](https://www.youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1)**

‎
‎
## 🔑 License

This software is licensed under the GNU General Public License v3 (GPL-3) licence. Please see https://www.gnu.org/licenses/gpl-3.0.en.html for more information.

‎
‎
## ℹ Disclaimer

This software is provided "As is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. **I cannot be held personally responsible if usage of this software results in loss of work or breakage of your operating system**.
