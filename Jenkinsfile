pipeline {

    agent none

    stages {
        stage('Build') {
            agent { 
                dockerfile {
                    additionalBuildArgs  '--entrypoint \'\''
                } 
            }
            steps {
                sh 'dotnet /app/dotnetapp/out/dotnetapp.dll'
            }
        }
        stage('Test') {
            agent { dockerfile true }
            steps {
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            agent { dockerfile true }
            steps {
                echo 'Deploying....'
            }
        }
    }
}
