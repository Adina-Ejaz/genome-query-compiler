# Genome Query Compiler

### A C# Domain-Specific Language for Basic DNA Sequence Analysis

**Genome Query Compiler** is a university Computer Science project that combines compiler design with introductory genomic sequence analysis.

The project implements a small domain-specific language (DSL) that allows users to perform operations on DNA sequences through simple genomic commands. It was developed in C# using Windows Forms and demonstrates how core Computer Science concepts can be applied to biological sequence data.

## Project Overview

The system accepts genomic queries written using a simple command-based language. These commands are processed through a compiler-style pipeline consisting of:

**User Query → Lexer → Parser → Symbol Table → Executor → Result**

The project was designed as a learning project at the intersection of **Computer Science and genomics**, providing practical experience in processing and analysing biological sequence data computationally.

## Genomic Operations

The compiler supports several basic DNA sequence operations:

* **Load DNA sequences** into the system
* **Search for DNA motifs** and report their positions
* **Count codons** within a DNA sequence
* **Translate DNA sequences** into amino-acid representations
* **Perform nucleotide substitutions** at specified positions

Example commands include:

```text
LOAD sample "ATGTTTATGATG"
FIND MOTIF "ATG" IN sample
COUNT CODONS IN sample
TRANSLATE sample
MUTATE sample AT 4 TO "C"
```

## Compiler Architecture

The project follows a simplified compiler architecture:

```text
                 User Query
                     │
                     ▼
                ┌─────────┐
                │  Lexer  │
                └────┬────┘
                     │
                  Tokens
                     │
                     ▼
                ┌─────────┐
                │ Parser  │
                └────┬────┘
                     │
                     ▼
              ┌─────────────┐
              │ Symbol Table│
              └──────┬──────┘
                     │
                     ▼
                ┌─────────┐
                │ Executor│
                └────┬────┘
                     │
          ┌──────────┼──────────┐
          ▼          ▼          ▼
       Motif      Codon      Translation
       Search      Count      / Mutation
```

### Lexer

The lexer converts the user's command into tokens such as:

* Keywords
* Identifiers
* Numbers
* Strings

Regular expressions are used to identify the different token types.

### Parser

The parser checks whether commands follow the expected grammar.

For example, a command beginning with `FIND` is checked for the expected `MOTIF`, sequence string, `IN` keyword and sequence identifier.

The parser also reports invalid or unexpected commands.

### Symbol Table

The symbol table stores loaded DNA sequences using their identifiers.

Each sequence is represented as a DNA symbol containing its name, type and sequence value.

### Executor

The executor performs the actual sequence operations, including motif searching, codon counting, translation and nucleotide mutation.

## Example

A DNA sequence can be loaded into the system and subsequently analysed using genomic commands.

For example:

```text
LOAD sample "ATGTTTATGATG"

FIND MOTIF "ATG" IN sample

COUNT CODONS IN sample

TRANSLATE sample
```

This demonstrates how a compiler-style interface can be used to perform simple computational analysis of biological sequences.

## Technologies

* **C#**
* **.NET / Windows Forms**
* **Visual Studio**
* Regular Expressions
* Object-Oriented Programming
* Compiler Design
* Data Structures

## Computer Science Concepts

This project provided practical experience with:

* Lexical analysis
* Parsing
* Domain-specific languages
* Symbol tables
* Regular expressions
* Object-oriented programming
* Dictionaries and collections
* Error handling
* Desktop GUI development
* Modular software design

## Genomics Concepts

The project provided an early practical introduction to computational genomics, including:

* DNA nucleotide sequences
* Sequence motifs
* Codons
* DNA-to-protein translation
* Nucleotide substitutions
* Basic sequence analysis

## Limitations

This project is an educational prototype rather than a clinical bioinformatics tool.

The sequence translation functionality uses a simplified codon mapping and does not implement the complete biological genetic code. Similarly, the mutation functionality demonstrates basic nucleotide substitution rather than clinical variant interpretation.

The project does not use patient data or make clinical or diagnostic claims.

## Future Development

Potential extensions could include:

* Support for the complete standard genetic code
* FASTA file input
* More advanced sequence searching
* Support for additional sequence operations
* Improved validation of biological sequences
* Integration with publicly available genomic resources

## Relevance to Computational Genomics

This project represents an early application of Computer Science to biological data. It provided experience in designing software that processes DNA sequences while developing a foundation in both computational thinking and genomic concepts.

It also provided a foundation for later work involving genomic quality control, sequencing data and variant analysis.

---

**Author:** Adina Ejaz
**Project:** University Semester Project
**Language:** C#
**Domain:** Computer Science / Computational Genomics
