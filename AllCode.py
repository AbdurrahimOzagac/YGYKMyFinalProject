import os

output_file = "allfile.txt"
script_name = os.path.basename(__file__)   # Name of this script file
exclude_dirs = {"bin", "obj"}              # Directories to exclude completely

# ----------------------------
# Build folder tree structure
# ----------------------------
def build_tree(path, prefix=""):
    tree = ""
    entries = sorted(os.listdir(path))

    for index, entry in enumerate(entries):
        full_path = os.path.join(path, entry)

        # Skip bin and obj folders
        if entry.lower() in exclude_dirs and os.path.isdir(full_path):
            continue

        # Skip this script and output file in the tree too
        if entry == script_name or entry == output_file:
            continue

        connector = "└── " if index == len(entries) - 1 else "├── "
        tree += prefix + connector + entry + "\n"

        if os.path.isdir(full_path):
            extension = "    " if index == len(entries) - 1 else "│   "
            tree += build_tree(full_path, prefix + extension)

    return tree


# ----------------------------
# Write file contents
# ----------------------------
with open(output_file, "w", encoding="utf-8") as out:

    # Tree structure section
    out.write("=" * 80 + "\n")
    out.write("PROJECT TREE STRUCTURE\n")
    out.write("=" * 80 + "\n\n")
    out.write(build_tree("."))

    # File contents section
    out.write("\n\n" + "=" * 80 + "\n")
    out.write("FILES CONTENTS\n")
    out.write("=" * 80 + "\n")

    for root, dirs, files in os.walk(".", topdown=True):

        # Exclude bin and obj folders from recursion
        dirs[:] = [d for d in dirs if d.lower() not in exclude_dirs]

        for file in files:
            file_path = os.path.join(root, file)

            # Skip this script and output file
            if os.path.basename(file_path) in {script_name, output_file}:
                continue

            try:
                # Read file content safely
                with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
                    content = f.read()

                # Write file content into output
                out.write("\n\n" + "=" * 80 + "\n")
                out.write(f"FILE: {file_path}\n")
                out.write("=" * 80 + "\n")
                out.write(content)

            except Exception as e:
                # If file cannot be read
                out.write("\n\n" + "=" * 80 + "\n")
                out.write(f"FILE: {file_path} (READ ERROR: {e})\n")
                out.write("=" * 80 + "\n")
                continue

print("Done! allfile.txt has been created.")
