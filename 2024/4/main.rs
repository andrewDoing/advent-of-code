fn main() {
    // read in text file to string
    let contents = std::fs::read_to_string("input.txt").expect("Failed to read file");

    // parse the text file into a 2d vector
    let mut lines = contents.lines(); // split the contents into lines
    let n: usize = lines.next().unwrap().parse().unwrap(); // read the first line as the size of the matrix
    let mut matrix: Vec<Vec<i32>> = Vec::new(); // initialize an empty 2D vector to store the matrix
    for _ in 0..n {
        let line = lines.next().unwrap(); // read the next line
        let row: Vec<i32> = line.split_whitespace().map(|x| x.parse().unwrap()).collect(); // split the line into numbers and parse them into integers
        matrix.push(row); // add the row to the matrix
    }

    // function that searches the matrix recursively
    fn search(matrix: &Vec<Vec<i32>>, x: usize, y: usize, n: usize) -> bool {
        // possible values are capital x, m, a, s
        // we are searching for the word "xmas"
        // if we find the word "xmas" we return true
        // valid values are 0, 1, 2, 3

        return search(matrix, x + matrix[x][y] as usize, y, n) || search(matrix, x, y + matrix[x][y] as usize, n); // recursively search in the matrix
    }

    // call the search function
    let result = search(&matrix, 0, 0, n); // start the search from the top-left corner of the matrix

    // print the result
    if result {
        println!("Yes"); // print "Yes" if the word "xmas" is found
    } else {
        println!("No"); // print "No" if the word "xmas" is not found
    }
}